echo IV_GIT_RELEASE_CREATOR_STARTING...
echo IV_CREATING_FOLDERS...
MD .\IV_Gallery_GIT_Release\IV_Gallery
MD .\IV_Gallery_GIT_Release\IV_Gallery\iv_shaders_cache
echo IV_CREATE_FOLDERS_COMPLETE!!!
echo IV_COPING_MAIN_PROGRAMM_AND_INCLUDES...
copy .\IV_Gallery.exe .\IV_Gallery_GIT_Release\IV_Gallery
copy .\IV_Gallery_Checkers_Core.dll .\IV_Gallery_GIT_Release\IV_Gallery
copy .\IV_Sound_Master.dll .\IV_Gallery_GIT_Release\IV_Gallery
copy .\SharpDX.Desktop.dll .\IV_Gallery_GIT_Release\IV_Gallery
copy .\SharpDX.dll .\IV_Gallery_GIT_Release\IV_Gallery
copy .\SharpDX.Direct3D11.dll .\IV_Gallery_GIT_Release\IV_Gallery
copy .\SharpDX.DXGI.dll .\IV_Gallery_GIT_Release\IV_Gallery
copy .\SharpDX.Mathematics.dll .\IV_Gallery_GIT_Release\IV_Gallery
copy .\SharpDX.D3DCompiler.dll .\IV_Gallery_GIT_Release\IV_Gallery
copy .\System.Buffers.dll .\IV_Gallery_GIT_Release\IV_Gallery
copy .\System.Memory.dll .\IV_Gallery_GIT_Release\IV_Gallery
copy .\System.Numerics.Vectors.dll .\IV_Gallery_GIT_Release\IV_Gallery
copy .\System.Runtime.CompilerServices.Unsafe.dll .\IV_Gallery_GIT_Release\IV_Gallery
copy .\LibVLCSharp.dll .\IV_Gallery_GIT_Release\IV_Gallery
copy .\LibVLCSharp.WinForms.dll .\IV_Gallery_GIT_Release\IV_Gallery

copy .\iv_shaders_cache\gallery_test_pixelShader.hlsl .\IV_Gallery_GIT_Release\IV_Gallery\iv_shaders_cache
copy .\iv_shaders_cache\gallery_test_vertexShader.hlsl .\IV_Gallery_GIT_Release\IV_Gallery\iv_shaders_cache

echo IV_COPIED_MAIN_PROGRAMM_AND_INCLUDES!!!
echo IV_ARCHIVE_MAIN_FOLDER_FOR_RELEASING_THAT...
"C:\Program Files\WinRAR\WinRAR.exe" a -ag -m5 ".\IV_Gallery_GIT_Release\IV_Gallery_Release.rar" ".\IV_Gallery_GIT_Release"
echo IV_MAIN_FOLDER_WAS_ARCHIVED!!!
pause
