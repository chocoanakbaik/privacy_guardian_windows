# Layer Boundaries

The application is organized around explicit boundaries:

1. Presentation / Windows UI
2. Application coordination
3. Input and document processing
4. Text processing
5. Privacy analysis
6. Evidence and result processing
7. Reporting
8. Security and storage infrastructure

Presentation code must not become the home for core analysis logic. Core analysis must remain independently testable.
