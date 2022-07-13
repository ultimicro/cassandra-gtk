project('cassandra-gtk', ['c', 'vala'], version : '0.1')

dependencies = [
    dependency('glib-2.0'),
    dependency('gobject-2.0'),
]

sources = [
    'src/main.vala'
]

exe = executable('cassandra-gtk', sources, dependencies : dependencies, install : true)
