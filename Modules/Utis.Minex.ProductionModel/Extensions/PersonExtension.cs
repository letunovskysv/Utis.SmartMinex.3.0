using Utis.Minex.ProductionModel.Catalog.Organize;

namespace Utis.Minex.ProductionModel.Extensions
{
    public static class PersonExtension
    {
        public static string GetFullName(this Person person) 
            => person != null ?  $"{person.Lastname} {person.Firstname} {person.Middlename}" : null;
    }
}
