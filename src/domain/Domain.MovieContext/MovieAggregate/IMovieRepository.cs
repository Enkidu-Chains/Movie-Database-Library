using Domain.Common;

namespace Domain.MovieContext.MovieAggregate;

public interface IMovieRepository : IRepository<Movie>
{
	public Movie? FindByNameInSet(string name, IEnumerable<MovieId> movieIds);
}
