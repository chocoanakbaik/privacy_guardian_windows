# Development Module Ownership

This document defines the scaffold boundaries for Chici 1 and Chici 2.

Formen (`hasby4726`) supervises structure, scope, integration boundaries, and quality. Formen does not implement feature logic unless explicitly instructed by the project owner.

## Core rule

Each feature/system owns its implementation files. Avoid placing unrelated logic into another module merely because the code is convenient there.

## Main boundaries

- `src/input`: input acquisition and input validation.
- `src/core/document`: document extraction, cleaning, and segmentation.
- `src/core/text`: generic text normalization and segmentation.
- `src/core/analysis/context`: context, subject/object, conditions, exceptions, and negation.
- `src/core/analysis/rules`: reusable rule definitions and matching infrastructure.
- `src/core/analysis/categories`: information-category detection.
- `src/core/analysis/collection`: data collection analysis.
- `src/core/analysis/usage`: data usage and purpose analysis.
- `src/core/analysis/sharing`: data sharing and recipient analysis.
- `src/core/analysis/retention`: retention and deletion analysis.
- `src/core/analysis/tracking`: tracking technology analysis.
- `src/core/analysis/rights`: user-rights analysis.
- `src/core/analysis/clauses`: important, conditional, exception, and legal-disclosure clauses.
- `src/core/analysis/scoring`: risk factors, score calculation, classification, and explanations.
- `src/core/evidence`: evidence extraction, location, context, and mapping.
- `src/core/results`: aggregation and validation of analysis results.
- `src/core/report`: report construction and presentation data.
- `src/security`: input safety, temporary data, logging, and privacy boundaries.
- `src/storage`: local persistence and storage contracts.
- `src/windows`: desktop presentation, controllers, services, and UI state.

## Implementation rule

Scaffold files contain no business logic. Assigned development agents own the implementation and tests for their modules. Cross-module changes must respect the contracts and dependency boundaries documented by the project.
