fx_version 'bodacious'
game 'gta5'

files {
    'Newtonsoft.Json.dll',
    'static/index.css',
    'static/index.js',
    'static/index.html',
    'static/*.png'
}

client_script 'Client/*.net.dll'
server_script 'Server/*.net.dll'

author 'zabbix-byte'
version '1.0.0'
description 'ztzbx player system'

dependencies {
    "core-ztzbx",
    "fivem-mysql",
    "notification"
}

ui_pages {
    'static/index.html'
}

client_exports {
    "updateShoes",
    "getShoes"
}

