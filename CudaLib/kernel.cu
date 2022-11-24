#include "cuda_runtime.h"
#include "device_launch_parameters.h"

#include <stdio.h>
#include <iostream>
#include <vector>
#include "CudaLib.h"

#define byte unsigned char

namespace CudaLib
{
#if 0
}	// indent guard
#endif

__global__ void cudaDifference(int *a, int *b)
{
	int i = threadIdx.x + blockIdx.x * blockDim.x;
	b[i] = a[i] * 2;
	return;
}

void computeDifference(int *a, int *b, int n)
{
	int byteCount = n * sizeof(int);
	int *cudaA;
	int *cudaB;
	cudaMalloc(&cudaA, byteCount);
	cudaMalloc(&cudaB, byteCount);
	cudaMemcpy(cudaA, a, byteCount, cudaMemcpyHostToDevice);

	dim3 blockSize = (1, 1);
	cudaDifference <<<blockSize, 1024>>> (cudaA, cudaB);
	cudaDeviceSynchronize();

	cudaMemcpy(b, cudaB, byteCount, cudaMemcpyDeviceToHost);
	cudaFree(cudaA);
	cudaFree(cudaB);
}
}
