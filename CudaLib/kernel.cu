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

__global__ void cudaDifference(int* a, int* b, int* c)
{
	int i = threadIdx.x + blockIdx.x * blockDim.x;
	c[i] = a[i] + b[i];
	return;
}

__global__ void cudaDifferenceBytes(int* a, int* b, int* c)
{
	int i = threadIdx.x + blockIdx.x * blockDim.x;
	byte* aBytes = (byte*)a;
	aBytes[0] = 200;
	aBytes[1] = 200;
	aBytes[2] = 200;
	aBytes[3] = 200;

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

void computeDifference2(int* a, int* b, int* c, int n)
{
	int byteCount = n * sizeof(int);
	int* cudaA;
	int* cudaB;
	int* cudaC;

	cudaMalloc(&cudaA, byteCount);
	cudaMalloc(&cudaB, byteCount);
	cudaMalloc(&cudaC, byteCount);

	cudaMemcpy(cudaA, a, byteCount, cudaMemcpyHostToDevice);
	cudaMemcpy(cudaB, b, byteCount, cudaMemcpyHostToDevice);

	dim3 blockSize = (1, 1);
	cudaDifference << <blockSize, 1024 >> > (cudaA, cudaB, cudaC);
	cudaDeviceSynchronize();

	cudaMemcpy(c, cudaC, byteCount, cudaMemcpyDeviceToHost);

	cudaFree(cudaA);
	cudaFree(cudaB);
	cudaFree(cudaC);
}

void computeDifferenceBytes(int* a, int* b, int* c, int n)
{
	int byteCount = n * sizeof(int);
	int* cudaA;
	int* cudaB;
	int* cudaC;

	cudaMalloc(&cudaA, byteCount);
	cudaMalloc(&cudaB, byteCount);
	cudaMalloc(&cudaC, byteCount);

	cudaMemcpy(cudaA, a, byteCount, cudaMemcpyHostToDevice);
	cudaMemcpy(cudaB, b, byteCount, cudaMemcpyHostToDevice);

	dim3 blockSize = (1, 1);
	cudaDifferenceBytes << <blockSize, 1024 >> > (cudaA, cudaB, cudaC);
	cudaDeviceSynchronize();

	cudaMemcpy(a, cudaA, byteCount, cudaMemcpyDeviceToHost);

	cudaFree(cudaA);
	cudaFree(cudaB);
	cudaFree(cudaC);
}
}
