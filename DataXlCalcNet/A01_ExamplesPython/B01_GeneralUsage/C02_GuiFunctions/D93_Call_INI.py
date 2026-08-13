# See: https://docs.python.org/3/library/configparser.html#quick-start


import os
from xlcalcnet import userpaths
import configparser


def ini_demo_write():
    config_path = userpaths.get_local_appdata()
    config_path = os.sep.join([config_path, 'XlCalcNetIDE'])
    config_fname = os.sep.join([config_path, 'example.ini'])
    print(config_path)
    print(config_fname)

    if not os.path.exists(config_path): 
        os.makedirs(config_path)

    config = configparser.ConfigParser()
    config['DEFAULT'] = {'ServerAliveInterval': '45',
                         'Compression': 'yes',
                         'CompressionLevel': '9'}
    config['forge.example'] = {}
    config['forge.example']['User'] = 'hg'
    config['topsecret.server.example'] = {}
    topsecret = config['topsecret.server.example']
    topsecret['Port'] = '50022'     # mutates the parser
    topsecret['ForwardX11'] = 'no'  # same here
    config['DEFAULT']['ForwardX11'] = 'yes'
    with open(config_fname, 'w') as configfile:
      config.write(configfile)


def ini_demo_read():
    config_path = userpaths.get_local_appdata()
    config_path = os.sep.join([config_path, 'XlCalcNetIDE'])
    config_fname = os.sep.join([config_path, 'example.ini'])
    print(config_path)
    print(config_fname)

    config = configparser.ConfigParser()
    config.sections()

    config.read(config_fname)

    config.sections()

    'forge.example' in config

    'python.org' in config

    config['forge.example']['User']

    config['DEFAULT']['Compression']

    topsecret = config['topsecret.server.example']
    topsecret['ForwardX11']

    topsecret['Port']

    for key in config['forge.example']:
        print(key)

    config['forge.example']['ForwardX11']



if __name__ == '__main__':
    ini_demo_write()
    ini_demo_read()


