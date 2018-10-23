namespace SppdDocs.Infrastructure.DbAccess.Seeders
{
    internal interface IDbSeeder
    {
        /// <summary>
        ///     Determines the order in which seeders will get called.
        ///     Seeder with a lower priority will be seeded first.
        /// </summary>
        int Priority { get; }

        /// <summary>
        ///     Seeds this data.
        /// </summary>
        void Seed();
    }
}