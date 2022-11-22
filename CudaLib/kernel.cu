#include "cuda_runtime.h"
#include "device_launch_parameters.h"

#include <stdio.h>

#include "CudaLib.h"

namespace CudaLib
{
#if 0
}	// indent guard
#endif


void complexCalcOriginal(int *a, int *b, int n)
{
	for (int i = 0; i < n; i++) {
		b[i] = a[i] * 2;
	}
}


__global__ void complexCalcFastLoop(int *a, int *b, int n)
{
	int i = threadIdx.x;
	if (i < n) {
		b[i] = a[i] * 2;
	}
}

void complexCalcFast(int *a, int *b, int n)
{
	int *dIn;
	int *dOut;
	cudaMallocHost((void**)&dIn, n * sizeof(int));
	cudaMallocHost((void**)&dOut, n * sizeof(int));
	cudaMemcpy(dIn, a, n * sizeof(int), cudaMemcpyHostToDevice);

	complexCalcFastLoop <<<1, n>>> (dIn, dOut, n);
	cudaDeviceSynchronize();

	cudaMemcpy(b, dOut, n * sizeof(int), cudaMemcpyDeviceToHost);
	cudaFree(dIn);
	cudaFree(dOut);
}

}
