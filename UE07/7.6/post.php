<?php
    require("init.php");
    include("header.php");
    echo"<h1>Post.php</h1>";
    $postRepository=new \App\Post\PostRepository($pdo);
    $post=$postRepository->fetchPost($_GET["id"]);
?>
<div class="panel panel-default">
    <div class="panel-heading">
        <h3 class="panel-title"><?php echo $post->title; ?></h3>
    </div>
    <div class="panel-body">
        <?php echo nl2br($post->content); ?>
    </div>
</div>
<?php include("footer.php"); ?>