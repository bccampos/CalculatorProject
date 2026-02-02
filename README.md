# CalculatorProject

## Overview

This project implements a string calculator that parses and calculates numbers from various formatted inputs. It includes practices using SOLID principles, design patterns, dependency injection, and unit testing.

## Usage Examples

### Basic Addition
```
> 1,2
1+2 = 3
```
### Newline Delimiters
```
> 1\n2\n3
1+2+3 = 6
```
### Custom Delimiters
```
> //;\n1;2;3
1+2+3 = 6

> //[***]\n1***2***3
1+2+3 = 6

> //[*][!!][r9r]\n11r9r22*33!!44
11+22+33+44 = 110
```
### Invalid Values
```
> 2,,4,rrrr,1001,6
2+0+4+0+0+6 = 12
```
### Error Handling
```
> -1,-2,3
Error: Negatives not allowed: -1,-2

> 1,2,3
Error: Input contains more than 2 number(s).
```

## Architecture

The project follows DDD with a clean architecture

<img width="474" height="327" alt="image" src="https://github.com/user-attachments/assets/5af16c3a-bf16-4822-8e16-247ab215ec3e" />

<img width="797" height="407" alt="image" src="https://github.com/user-attachments/assets/7d71f2c4-b74e-4e15-8057-5430403137f3" />

### ConsoleApp
**Entry point & Dependency Injection**
- Application entry point
- DI configuration 
- User interface handling

### ApplicationLayer
**Application services**
- Orchestrates domain operations
- Use case implementation

### Domain
**Core business logic**
- **Main domain entity**: `Calculator` - Core calculation logic
- **Domain services**: Parsing strategies, number validation
- **Value Objects**: `CalculationResult` 
- **Domain exceptions**: Custom exceptions for business rules
- **No dependencies** on other layers

### Infrastructure
**Technical concerns**

### Tests
**All tests covered in Domain**
- Tests for: Basic operations, delimiters, validation, custom formats, formula display





