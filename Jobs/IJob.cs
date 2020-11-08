namespace Bable.Jobs
{
	public interface IJob
	{
		void Start();
		void Pauze();
		void Stop();
	}

}
