#pragma once

namespace CudaLib
{
#if 0
}	// indent guard
#endif

#ifdef DLL_EXPORT
extern "C" __declspec(dllexport) void complexCalcOriginal(int* a, int* b, int n);
extern "C" __declspec(dllexport) void complexCalcFast(int* a, int* b, int n);
#else
__declspec(dllimport) void complexCalcOriginal(int *a, int*b, int n);
__declspec(dllimport) void complexCalcFast(int *a, int*b, int n);
#endif
}