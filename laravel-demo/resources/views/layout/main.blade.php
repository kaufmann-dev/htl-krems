<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8">
        <title>@yield('title')</title>
    </head>
    <body>
        <ul>
            <li><a  href="/">Dashboard</a></li>
            <li><a  href="/projects">Projects</a></li>
            <li><a  href="/customers">Customers</a></li>
        </ul>
        @yield('content')
    </body>
</html>