namespace PhoneContact.DataAccess.Concrete.DTO
{
	public class ResponseBase<T>
	{
		public ResponseBase(T data)
		{
			this.Data = data;
		}

		public string Message { get; set; }

		public bool Success { get; set; } = true;

		public T Data { get; set; }
	}
}