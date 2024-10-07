
namespace Utis.Minex.Common
{
    public static class LabelKeyExtensions
    {
        public static LabelKey ToLabelKey(this LabelKeyDTO labelKeyDTO)
        {
            if (labelKeyDTO == default)
                return default;

            return 
                new LabelKey(
                    labelKeyDTO.Label, 
                    labelKeyDTO.Type
                    );
        }

        public static LabelKeyDTO ToLabelKeyDTO(this LabelKey labelKey)
        {
            if (labelKey == default)
                return default;

            return 
                new LabelKeyDTO()
                {
                    Label = labelKey.Label,
                    Type  = labelKey.Type,
                };
        }
    }
}
