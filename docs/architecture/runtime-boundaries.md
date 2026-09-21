# Runtime Boundaries

The application is a Windows desktop process. Core analysis should remain local-first and must not silently transmit policy content. Temporary data must have a defined lifecycle. Expensive operations must be bounded for low-resource devices.
