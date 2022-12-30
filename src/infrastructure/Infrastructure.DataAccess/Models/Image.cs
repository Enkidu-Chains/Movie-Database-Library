namespace Infrastructure.DataAccess.Models;

class Image
{
	public int Id { get; set; }

	public string GoogleDriverFileId { get; set; }

	public int MovieId { get; set; }

	public Movie Movie { get; set; }
}