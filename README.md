# Aviation Calc Util NET

This is a .NET Wrapper for the native aviation-calc-util library. This wrapper uses P/Invoke to interop between .NET and native Rust code.
The wrapper is built on the .NET Standard 2.0 framework and is therefore compatible with .NET Framework and .NET Core projects.

## Dependencies
The project depends on the following libraries
- **[Aviation Calc Util FFI](https://github.com/997R8V10/aviation-calc-util-ffi)**
	- This is consumed as a NuGet package.
	- This wraps [Aviation Calc Util](https://github.com/997R8V10/aviation-calc-util)