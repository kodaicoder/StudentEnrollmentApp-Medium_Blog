namespace StudentEnrollment.Data
{
	public abstract class BaseEntity
	{
		public int Id { get; set; }
		public DateTime CreatedDate { get; set; }
		public string CreateBy { get; set; }
		public DateTime UpdatedDate { get; set; }
		public string UpdateBy { get; set; }
	}

}