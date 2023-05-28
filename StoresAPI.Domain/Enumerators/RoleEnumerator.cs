namespace StoresAPI.Domain.Enumerators
{
    public enum RoleEnumerator
    {
        // Can be used as security level.
        // Example: GlobalAdmin can access everything, Salesman can use the least features since he is the lowest level 
        GlobalAdmin,
        StoreAdmin,
        Manager,
        Salesman
    }
}
