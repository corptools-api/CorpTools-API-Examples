# PHP Examples

## Environment Configurations
Create an `.env` file at the root of the `php` folder with the following properties defined:

```
ACCESS_KEY='<access-key>'
SECRET_KEY='<secret-key>'
API_URL='https://api.corporatetools.com'

# Optional, request dependent
COMPANY_ID='<company-id>'
JURISDICTION='<jurisdiction-abbreviation>'
DOCUMENT_ID='<document-id>'
```

## Dependency Versions

- PHP 8.2.8
- Composer 2.5.8

## Installation steps for MacOS

1. Install PHP:

	`brew install php`

2. Install composer (PHP package manager):
	
	`php -r "copy('https://getcomposer.org/installer', 'composer-setup.php');"`

	`php -r "if (hash_file('sha384', 'composer-setup.php') === 'e21205b207c3ff031906575712edab6f13eb0b361f2085f1f1237b7126d785e826a450292b6cfd1d64d92e6563bbde02') { echo 'Installer verified'; } else { echo 'Installer corrupt'; unlink('composer-setup.php'); } echo PHP_EOL;"`

	`php composer-setup.php`

	`php -r "unlink('composer-setup.php');"`

	`sudo mv composer.phar /usr/local/bin/composer`

## Examples using CURL

### Getting Started
1. `composer install`
2. `composer run <script-name>` (See `composer.json` for scripts starting with `curl-*`)

## Examples using [Guzzle](https://docs.guzzlephp.org/en/stable/index.html)

### Getting Started
1. `composer install`
2. `composer run <script-name>` (See `composer.json` for scripts starting with `guzzle-*`)
3. `php guzzle_download.php` 
NOTE: The `guzzle_download.php` script expects a directory named `downloads` at the root of the `php` folder for the PDF files to download to.
