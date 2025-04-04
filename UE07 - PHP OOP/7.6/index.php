<?php
    require("init.php");
    include("header.php");
    echo"<h1>Das ist die Startseite des Blogs.</h1>";
    $postRepository = new \App\Post\PostRepository($pdo);
    $posts = $postRepository->fetchPosts();
    echo"<ul>";
    foreach($posts as $post){
        echo"<li><a href='post.php?id=".$post->id."'>".$post->title."</a></li>";
    }
    echo"</ul>";
    include("footer.php");
?>