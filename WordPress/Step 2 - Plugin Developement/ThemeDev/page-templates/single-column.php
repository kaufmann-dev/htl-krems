<?php
/*
Template Name: Single Column Template
Template Post Type: post, page
*/
get_header(); ?>
    <div class="container">
        <div class="row">
            <main class="col-12">
                <?php
                if (have_posts()) : // check if the loop has returned any posts.
                    while (have_posts()) : // loop through each returned post.
                        the_post(); // set up the content so we can use template tags like the_title().
                        the_title(); // output the post title.
                        the_content(); // output the post content.
                    endwhile;
                else :
                    echo 'No Page Found'; // output an error message if there are no posts.
                endif;
                ?>
            </main>
        </div>
    </div>
<?php get_footer(); ?>