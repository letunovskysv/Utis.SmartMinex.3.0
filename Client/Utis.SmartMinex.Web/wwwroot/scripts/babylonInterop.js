var map;
const TScheme = function (id, data) {
    const canvas = document.getElementById(id);
    const _data = data;
    const _trianglesVerticesMode = true;
    let engine;
    let scene;
    let camera, axicam;
    let axiscube;

    const drawAxisCube = () => {
        const axis = (root, n, x, y, z, r, g, b) => {
            const mat = new BABYLON.StandardMaterial('axis' + n, scene);
            mat.emissiveColor = new BABYLON.Color3(r, g, b);
            mat.alpha = 1;
            const c = BABYLON.MeshBuilder.CreateCylinder('axis' + n, { height: 0.2, diameter: 0.05, sideOrientation: 0 }, scene);
            c.layerMask = 0x80000000;
            c.parent = root;
            c.position.x = x;
            c.position.y = y;
            c.position.z = z;
            c.rotation.x = n === 'z' ? Math.PI / 2 : 0;
            c.rotation.z = n === 'x' ? -Math.PI / 2 : 0;
            c.material = mat;
            const c2 = BABYLON.MeshBuilder.CreateCylinder('arr' + n, { height: 0.1, diameterBottom: 0.075, diameterTop: 0, sideOrientation: 0 }, scene);
            c2.layerMask = c.layerMask;
            c2.parent = c;
            c2.material = mat;
            c2.position.y = 0.15;
            return c;
        };
        axiscube = axis(null, 'y', 0, 0.1, 0, 0, 0.6, 0);
        axis(axiscube, 'x', 0.1, -0.1, 0, 0.6, 0, 0);
        axis(axiscube, 'z', 0, -0.1, 0.1, 0, 0, 0.6);
    };

    const onMouseDown = (e, pick) => {
        if (pick.hit) {
            console.log(pick.pickedPoint);
        }
        switch (e.button) {
            case 0: // left
                break;
            case 2: // right
                break;
            case 1: // wheel button or middle button
                break;
        }
    };

    const createScene = () => {
        const scene = new BABYLON.Scene(engine);
        scene.useRightHandedSystem = true;
        scene.clearColor = new BABYLON.Color4(0, 0, 0, 0);

        camera = new BABYLON.ArcRotateCamera("camera", Math.PI / 2, Math.PI, 100, new BABYLON.Vector3(_data.origin.x, _data.origin.y, _data.origin.z), scene);
        camera.noRotationConstraint = true;
        camera.attachControl(canvas, true);

        //axicam = new BABYLON.FreeCamera("axicam", new BABYLON.Vector3(0, 10, 0), scene);
        //axicam.upVector = new BABYLON.Vector3(0, 0, 1);
        //axicam.setTarget(BABYLON.Vector3.Zero());
        //axicam.viewport = new BABYLON.Viewport(-0.45, -0.35, 1, 1);
        axicam = new BABYLON.ArcRotateCamera("axicam", -Math.PI / 2, 0, 10, new BABYLON.Vector3(0, 0, 0), scene);
        axicam.viewport = new BABYLON.Viewport(-0.45, -0.35, 1, 1);
        //axicam.mode = BABYLON.Camera.ORTHOGRAPHIC_CAMERA;
        axicam.layerMask = 0x80000000;

        scene.activeCameras.push(camera);
        scene.activeCameras.push(axicam);

        const light = new BABYLON.HemisphericLight("light", new BABYLON.Vector3(0, 0, 1000), scene);
        light.specular = new BABYLON.Color3(0, 0, 0);
        light.intensity = 0.7;

        var utmesh = new BABYLON.Mesh("utis", scene);
        utmesh.isPickable = true;
        //utmesh.MeshPrimitiveMode = BABYLON.MeshPrimitiveMode.TRIANGLE_STRIP;

        var mat = new BABYLON.StandardMaterial(scene);
        mat.alpha = 1;
        mat.backFaceCulling = false;
        utmesh.material = mat;

        var vrtx = new BABYLON.VertexData();
        if (_data.normals.length === 0)
            BABYLON.VertexData.ComputeNormals(_data.vertices, _data.indices, _data.normals);

        vrtx.positions = _data.vertices;
        vrtx.indices = _data.indices;
        vrtx.colors = _data.colors;
        vrtx.normals = _data.normals;

        vrtx.applyToMesh(utmesh);

        if (_trianglesVerticesMode) {
            BABYLON.MeshDebugPluginMaterial.PrepareMeshForTrianglesAndVerticesMode(utmesh);
            new BABYLON.MeshDebugPluginMaterial(utmesh.material, {
                mode: BABYLON.MeshDebugMode.TRIANGLES_VERTICES,
                wireframeVerticesColor: new BABYLON.Color3(0, 0, 0.8),
                wireframeThickness: 0.7,
                vertexColor: new BABYLON.Color3(0, 0, 0.8),
                vertexRadius: 1.2
            });
        }
        drawAxisCube();

        const dsm = new BABYLON.DeviceSourceManager(engine);
        dsm.onDeviceConnectedObservable.add((dev) => {
            console.log("onDeviceConnectedObservable: " + dev.deviceType);
        });

        scene.onPointerDown = onMouseDown;

        return scene;
    };

    return {
        init: () => {
            engine = new BABYLON.Engine(canvas, true);
            scene = createScene();
            engine.runRenderLoop(() => {
                if (axicam != null) {
                    axicam.alpha = camera.alpha;
                    axicam.beta = camera.beta;
                }
                scene.render();
            });
            window.addEventListener("resize", () => engine.resize());
        },
        test: () => {
           // var view = scene.getTransformMatrix();// '//camera.viewport;//.toGlobal(engine);
            //var w = view.width;
            //var h = view.height;

            var p = BABYLON.Vector3.Project(axiscube.position,
                BABYLON.Matrix.Identity(),
                scene.getTransformMatrix(),
                camera.viewport.toGlobal(engine));

            $alert(p);
            console.log("TEST: " + p);
        }
    }
}

export function createScheme(id, data) {
    map = new TScheme(id, data);
    map.init();
}

export function testScheme() {
    map.test();
}