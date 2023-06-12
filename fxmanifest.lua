fx_version 'bodacious'
game 'gta5'

files {
    'Newtonsoft.Json.dll',
}

client_script 'Client/*.net.dll'
server_script 'Server/*.net.dll'

author 'zabbix-byte'
version '1.0.0'
description 'ztzbx player system'

dependencies {
    "core-ztzbx",
    "fivem-mysql",
    "notification",
    "inventory"
}

ui_pages {
    'static/index.html'
}

client_exports {
    "updateShoes",
}

