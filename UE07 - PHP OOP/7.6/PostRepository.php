<?php
    namespace App\Post;

    class PostRepository{
        private $pdo;
        public function __construct(PDO $pdo)
        {
            $this->pdo=$pdo;
        }
        function fetchPosts(){
            $posts=$this->pdo->query("SELECT * FROM POSTS");
            $items=[];
            foreach($posts as $post){
                array_push($items, new PostModel($post["id"], $post["title"], $post["content"]));
            }
            return $items;
        }
        function fetchPost($id):PostModel{
            $stmt = $this->prepare("SELECT * FROM POSTS WHERE ID = :ID");
            $stmt->execute(["ID"->$id]);
            $postArray=$stmt->fetch();
            return new PostModel($postArray["id"], $postArray["title"], $postArray["content"]);
        }
    }
?>