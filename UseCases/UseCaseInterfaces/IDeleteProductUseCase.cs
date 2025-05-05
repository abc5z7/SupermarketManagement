using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.UseCaseInterfaces
{
	public interface IDeleteProductUseCase
	{
		public void Execute(int id);
	}
}
