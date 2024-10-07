var map;
const TScheme = function (id, data) {
    const canvas = $(id);
    const _data = data;
    let engine;
    let scene;
    let axiscube;

    const drawAxis = (x, y, z) => {
        const axis = (root, n, x, y, z, r, g, b) => {
            const mat = new BABYLON.StandardMaterial('axis' + n, scene);
            mat.diffuseColor = new BABYLON.Color3(r, g, b);
            mat.alpha = 1;
            mat.backFaceCulling = false;
            const c = BABYLON.MeshBuilder.CreateCylinder('axis' + n, { height: 2, diameter: 0.5, sideOrientation: 0 }, scene);
            c.parent = root;
            c.position.x = x;
            c.position.y = y;
            c.position.z = z;
            c.rotation.x = n === 'z' ? Math.PI / 2 : 0;
            c.rotation.z = n === 'x' ? -Math.PI / 2 : 0;
            c.material = mat;
            const c2 = BABYLON.MeshBuilder.CreateCylinder('arr' + n, { height: 1, diameterBottom: 0.75, diameterTop: 0, sideOrientation: 0 }, scene);
            c2.parent = c;
            c2.material = mat;
            c2.position.y = 1.5;
            return c;
        };
        axiscube = axis(null, 'y', x, y + 1, z, 0, 0, 1);
        axis(axiscube, 'x', 1, -1, 0, 0, 1, 0);
        axis(axiscube, 'z', 0, -1, 1, 1, 0, 0);
    };

    const createScene = () => {
        const scene = new BABYLON.Scene(engine);
        scene.clearColor = new BABYLON.Color4(0, 0, 0, 0);

        const camera = new BABYLON.ArcRotateCamera("camera", -Math.PI / 2, 0, 100, new BABYLON.Vector3(_data.origin.x, _data.origin.y, _data.origin.z), scene);
       // camera.setPosition(new BABYLON.Vector3(-1.7, 1.7, 100));
        camera.attachControl(canvas, true);

        const light = new BABYLON.HemisphericLight("light", new BABYLON.Vector3(0, 1, 0), scene);
        light.intensity = 0.7;

        var utisMesh = new BABYLON.Mesh("utis", scene);

        var mat = new BABYLON.StandardMaterial(scene);
        mat.alpha = 1;
        mat.diffuseColor = new BABYLON.Color3(1.0, 0.2, 0.7);
        mat.backFaceCulling = false;
        utisMesh.material = mat;

        var vrtx = new BABYLON.VertexData();
        BABYLON.VertexData.ComputeNormals(_data.vertices, _data.indices, _data.normals);

        vrtx.positions = _data.vertices;
        vrtx.indices = _data.indices;
        vrtx.colors = _data.colors;
        vrtx.normals = _data.normals;

        vrtx.applyToMesh(utisMesh);

        drawAxis(26606, 32052, -880);

        return scene;
    };

    return {
        init: () => {
            engine = new BABYLON.Engine(canvas, true);
            scene = createScene();
            engine.runRenderLoop(() => scene.render());
            window.addEventListener("resize", () => engine.resize());
        },
        test: () => {
            var view = scene.activeCamera.viewport.toGlobal(engine);
            //var w = view.width;
            //var h = view.height;
            $alert(view);
            console.log("TEST: " + view);
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