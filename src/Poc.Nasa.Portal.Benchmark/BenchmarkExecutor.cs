using BenchmarkDotNet.Attributes;
using Poc.Nasa.Portal.Domain.Models.PictureOfTheDayAggregate;
using Poc.Nasa.Portal.Infrastructure.UnitOfWork;

namespace Poc.Nasa.Portal.Benchmark;

public class BenchmarkExecutor
{
    private readonly IUnitOfWork _unitOfWork;

    public BenchmarkExecutor(IUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    [Benchmark]
    public void Execute()
    {
        Console.WriteLine("jjkljkljklxjkljklxjkclxjklcxjklxcjklxcjklxcjklxcjklxlck");
        CancellationTokenSource cts = new CancellationTokenSource();
        //await _unitOfWork.PictureOfTheDayRepository.Count(cts.Token);
    }
}