# InstallCustomCulture

Installs/uninstalls custom cultures (.NET CultureInfo objects) on the host system from the command prompt.

## Usage

The program must be run with administrator privilegies. Alternatively, you can run the whole command prompt as admin.
  
### Installation
    
    InstallCustomCulture install [culture-id] [culture-name] [based-on]
    
Example:

    InstallCustomCulture install en-HK "English (Hong Kong)" en-GB
  
### Uninstallation
    
    InstallCustomCulture uninstall [culture-id]
    
Example:

    InstallCustomCulture uninstall en-HK