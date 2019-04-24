extern "C" HANDLE __cdecl FontList_Create(void);
extern "C" int __cdecl  FontList_GetCount(HANDLE hFontList);
extern "C" LPTSTR __cdecl   FontList_GetFace(HANDLE hFontList, int iFace);
extern "C" BOOL __cdecl   FontList_Destroy(HANDLE hFontList);
