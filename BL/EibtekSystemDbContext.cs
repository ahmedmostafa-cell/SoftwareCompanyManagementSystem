using System;
using Domains;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BL
{
    public partial class EibtekSystemDbContext : IdentityDbContext<ApplicationUser>
    {
        public EibtekSystemDbContext()
        {
        }

        public EibtekSystemDbContext(DbContextOptions<EibtekSystemDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbClient> TbClients { get; set; }
        public virtual DbSet<TbEmployee> TbEmployees { get; set; }
        public virtual DbSet<TbEmployeeCategory> TbEmployeeCategories { get; set; }
        public virtual DbSet<TbEmployeeEvaluation> TbEmployeeEvaluations { get; set; }
        public virtual DbSet<TbExpenseCategory> TbExpenseCategories { get; set; }
        public virtual DbSet<TbExpenseTransaction> TbExpenseTransactions { get; set; }
        public virtual DbSet<TbMonthRecord> TbMonthRecords { get; set; }
        public virtual DbSet<TbPaidProjectInstallment> TbPaidProjectInstallments { get; set; }
        public virtual DbSet<TbPaidSalesEmplyeeInstallment> TbPaidSalesEmplyeeInstallments { get; set; }
        public virtual DbSet<TbProject> TbProjects { get; set; }
        public virtual DbSet<TbProjectInstallment> TbProjectInstallments { get; set; }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TbClient>(entity =>
            {
                entity.HasKey(e => e.ClientId);

                entity.ToTable("TbClient");

                entity.Property(e => e.ClientId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ClientCompanyDescription).HasMaxLength(200);

                entity.Property(e => e.ClientCompanyLocation).HasMaxLength(200);

                entity.Property(e => e.ClientImagePath).HasMaxLength(200);

                entity.Property(e => e.ClientName).HasMaxLength(200);

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbEmployee>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.ToTable("TbEmployee");

                entity.Property(e => e.EmployeeId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.EmployeeImagePath).HasMaxLength(200);

                entity.Property(e => e.EmployeeJobDescription).HasMaxLength(200);

                entity.Property(e => e.EmployeeSalary).HasMaxLength(200);

                entity.Property(e => e.EmployeeSalaryCalculate).HasMaxLength(200);

                entity.Property(e => e.EmployeeWorkHours).HasMaxLength(200);

                entity.Property(e => e.EmplyeeName).HasMaxLength(200);

                entity.Property(e => e.EmplyeeWorkHourValue).HasMaxLength(200);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.EmployeeCategory)
                    .WithMany(p => p.TbEmployees)
                    .HasForeignKey(d => d.EmployeeCategoryId)
                    .HasConstraintName("FK_TbEmployee_TbEmployeeCategory");
            });

            modelBuilder.Entity<TbEmployeeCategory>(entity =>
            {
                entity.HasKey(e => e.EmployeeCategoryId);

                entity.ToTable("TbEmployeeCategory");

                entity.Property(e => e.EmployeeCategoryId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.EmplyeeCategoryJobDescription).HasMaxLength(200);

                entity.Property(e => e.EmplyeeCategoryName).HasMaxLength(200);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbEmployeeEvaluation>(entity =>
            {
                entity.HasKey(e => e.EmployeeEvaluationId);

                entity.ToTable("TbEmployeeEvaluation");

                entity.Property(e => e.EmployeeEvaluationId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.EmployeeBasicWorkHours).HasMaxLength(200);

                entity.Property(e => e.EmployeeExtraWorkHours).HasMaxLength(200);

                entity.Property(e => e.EvaluationNumerical).HasMaxLength(200);

                entity.Property(e => e.EvaluationSyntax).HasMaxLength(200);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TbEmployeeEvaluations)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_TbEmployeeEvaluation_TbEmployee");
            });

            modelBuilder.Entity<TbExpenseCategory>(entity =>
            {
                entity.HasKey(e => e.ExpenseCategoryId);

                entity.ToTable("TbExpenseCategory");

                entity.Property(e => e.ExpenseCategoryId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.ExpenseCategoryDescription).HasMaxLength(200);

                entity.Property(e => e.ExpenseCategoryImage).HasMaxLength(200);

                entity.Property(e => e.ExpenseCategoryName).HasMaxLength(200);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbExpenseTransaction>(entity =>
            {
                entity.HasKey(e => e.ExpenseTransactionId);

                entity.ToTable("TbExpenseTransaction");

                entity.Property(e => e.ExpenseTransactionId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.ExpenseTransactionDescription).HasMaxLength(200);

                entity.Property(e => e.ExpenseTransactionDocument).HasMaxLength(200);

                entity.Property(e => e.ExpenseTransactionValue).HasMaxLength(200);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.ExpenseCategory)
                    .WithMany(p => p.TbExpenseTransactions)
                    .HasForeignKey(d => d.ExpenseCategoryId)
                    .HasConstraintName("FK_TbExpenseTransaction_TbExpenseCategory");
            });

            modelBuilder.Entity<TbMonthRecord>(entity =>
            {
                entity.HasKey(e => e.MonthRecordId);

                entity.ToTable("TbMonthRecord");

                entity.Property(e => e.MonthRecordId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CompanyValue).HasMaxLength(200);

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Expense).HasMaxLength(200);

                entity.Property(e => e.Fund).HasMaxLength(200);

                entity.Property(e => e.Income).HasMaxLength(200);

                entity.Property(e => e.ManagementValue).HasMaxLength(200);

                entity.Property(e => e.MonthName).HasMaxLength(200);

                entity.Property(e => e.MonthNumber).HasMaxLength(200);

                entity.Property(e => e.NetIncome).HasMaxLength(200);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.WithdrawalValue).HasMaxLength(200);

                entity.Property(e => e.Year).HasMaxLength(200);

                entity.Property(e => e.ZakahValue).HasMaxLength(200);
            });

            modelBuilder.Entity<TbPaidProjectInstallment>(entity =>
            {
                entity.HasKey(e => e.PaidProjectInstallmentId)
                    .HasName("PK_TbProjectPaidInstallment");

                entity.ToTable("TbPaidProjectInstallment");

                entity.Property(e => e.PaidProjectInstallmentId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.PaidProjectInstallmentDocument).HasMaxLength(200);

                entity.Property(e => e.PaidProjectInstallmentValue).HasMaxLength(200);

                entity.Property(e => e.ProjectInstallmentValue).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasMaxLength(200);

                entity.HasOne(d => d.ProjectInstallment)
                    .WithMany(p => p.TbPaidProjectInstallments)
                    .HasForeignKey(d => d.ProjectInstallmentId)
                    .HasConstraintName("FK_TbPaidProjectInstallment_TbProjectInstallment");

                entity.HasOne(d => d.SalesEmployee)
                    .WithMany(p => p.TbPaidProjectInstallments)
                    .HasForeignKey(d => d.SalesEmployeeId)
                    .HasConstraintName("FK_TbPaidProjectInstallment_TbEmployee");
            });

            modelBuilder.Entity<TbPaidSalesEmplyeeInstallment>(entity =>
            {
                entity.HasKey(e => e.PaidSalesEmplyeeInstallmentId)
                    .HasName("PK_TbSalesEmplyeeInstallment");

                entity.ToTable("TbPaidSalesEmplyeeInstallment");

                entity.Property(e => e.PaidSalesEmplyeeInstallmentId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.PaidSalesInstallmentValue).HasMaxLength(200);

                entity.Property(e => e.PaidSalesInstallmentValueDocument).HasMaxLength(200);

                entity.Property(e => e.SalesInstallmentValue).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.ProjectInstallment)
                    .WithMany(p => p.TbPaidSalesEmplyeeInstallments)
                    .HasForeignKey(d => d.ProjectInstallmentId)
                    .HasConstraintName("FK_TbPaidSalesEmplyeeInstallment_TbProjectInstallment");

                entity.HasOne(d => d.SalesEmployee)
                    .WithMany(p => p.TbPaidSalesEmplyeeInstallments)
                    .HasForeignKey(d => d.SalesEmployeeId)
                    .HasConstraintName("FK_TbPaidSalesEmplyeeInstallment_TbEmployee");
            });

            modelBuilder.Entity<TbProject>(entity =>
            {
                entity.HasKey(e => e.ProjectId);

                entity.ToTable("TbProject");

                entity.Property(e => e.ProjectId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.ProjectCost).HasMaxLength(200);

                entity.Property(e => e.ProjectDescription).HasMaxLength(200);

                entity.Property(e => e.ProjectInstallmentNumbers).HasMaxLength(200);

                entity.Property(e => e.ProjectName).HasMaxLength(200);

                entity.Property(e => e.ProjectSalesPrice).HasMaxLength(200);

                entity.Property(e => e.SalesEmployeePercentage).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.WorkingEmployessNumber).HasMaxLength(200);
            });

            modelBuilder.Entity<TbProjectInstallment>(entity =>
            {
                entity.HasKey(e => e.ProjectInstallmentId)
                    .HasName("PK_TbProjectInstallment_1");

                entity.ToTable("TbProjectInstallment");

                entity.Property(e => e.ProjectInstallmentId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.ProjectInstallmentDate).HasMaxLength(200);

                entity.Property(e => e.ProjectInstallmentDescription).HasMaxLength(200);

                entity.Property(e => e.ProjectInstallmentValue).HasMaxLength(200);

                entity.Property(e => e.SalesInstallmentValue).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.TbProjectInstallments)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_TbProjectInstallment_TbClient");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.TbProjectInstallments)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_TbProjectInstallment_TbProject");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
