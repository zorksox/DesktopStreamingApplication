#pragma once
#define byte unsigned char

namespace CudaLib
{
#if 0
}	// indent guard
#endif

#ifdef DLL_EXPORT
extern "C" __declspec(dllexport) void computeDifference(int* a, int* b, int n);

#else
__declspec(dllimport) void complexCalcFast(int *a, int*b, int n);
#endif
}