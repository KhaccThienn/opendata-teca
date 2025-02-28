namespace Infrastructure.Data
{
    public partial class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<TodoList> TodoLists => Set<TodoList>();

        public DbSet<TodoItem> TodoItems => Set<TodoItem>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder.HasDefaultSchema("DB_TEST_DEV").UseCollation("USING_NLS_COMP");

            builder.ApplyConfiguration(new TodoListTypeConfigurations());

            builder.ApplyConfiguration(new TodoItemTypeConfigurations());

            builder.HasSequence("ACCOM_FACILITY_SEQ");
            builder.HasSequence("ACCOM_USER_ROLE_SEQ");
            builder.HasSequence("ACCOM_USER_SEQ");
            builder.HasSequence("CONFIG_NOTI_STAY_SEQ");
            builder.HasSequence("CONTRACT_NUMBER_SEQ");
            builder.HasSequence("DM_QUOC_TICH_SEQ");
            builder.HasSequence("GOVERNING_BODY_SEQ");
            builder.HasSequence("NOTI_STAY_SEQ");
            builder.HasSequence("NOTIFICATION_STAY_CUSTOMER_ACCOM_SEQ");
            builder.HasSequence("REASON_STAY_SEQ");
            builder.HasSequence("REGIS_ACCOM_FACILITY_SEQ");
            builder.HasSequence("REGIS_ACCOM_REPRESENTATIVE_SEQ");
            builder.HasSequence("REGIS_GOVERNING_BODY_SEQ");
            builder.HasSequence("SCALE_TYPE_SEQ");
            builder.HasSequence("SEQ_DM_CHUC_VU_ID");
            builder.HasSequence("SEQ_HOTEL_CONFIG");
            builder.HasSequence("SHR_CONTRACT_TYPE_SEQUENCE");

            OnModelCreatingPartial(builder);

            base.OnModelCreating(builder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
