# Python Examples

## Environmental Configurations
The Python examples read in configurable properties from a shared `.env` file at the root directory of the project. (See the README.md in project root for directions on setting up the `.env` file.)

## Python Version
- Python 3.11.3
- PyJWT 2.7.0

## Installing Dependencies
- `pip3 install jwt`
- `pip3 install requests`
- `pip3 install PyJWT`
- `pip3 install python-dotenv`

## Getting Started
1. `python3 examples/<script-filename> <standalone-arg>` (see `examples` directory for example options)
	- The `<standalone-arg>` runs the script in a standalone example mode, the argument can be any value
2. `python3 examples/end-to-end/<script-filename>` 
	- More complex examples of a series of requests that depend upon each other 
	- These examples reuse the request classes from the `/examples/` folder 