<?php
/**
 * Plugin Name: Post Statistics
 * Description: Another amazing plugin.
 * Version: 1.0
 * Author: HTL Super Coder
 */

/**
 * https://developer.wordpress.org/reference/functions/add_action/
 * https://developer.wordpress.org/reference/hooks/admin_menu/
 */

class PostStat{
    function __construct(){
        add_action('admin_menu', 'pluginSettingMenuEntry');
        add_action('admin_init', array($this, 'settings'));
    }

    /**
     * 
     */

    function seeting(){
        add_settings_section($)
    }

    function pluginSettingMenuEntry(){
        add_options_page('Post Stat Settings' , 'Post Stat', 'manage_options', 'htl-post-stat', array($this, 'pluginSettingHTML'));
    }
    
    /**
     * Markup für die Umsetzung der Backend Page des HTL Post Stat Plugins
     */
    
    function pluginSettingHTML(){
        echo "<p>Hello</p>";
    }
}

new PostStat();
