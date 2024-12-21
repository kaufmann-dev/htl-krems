<?php
require_once("BaseInput.php");
require_once("Form.php");
require_once("Button.php");
require_once("TextInput.php");
require_once("PasswordInput.php");
$form = new Form();
$form->addElement(new TextInput('firstname', 'First name'));
$form->addElement(new TextInput('email', 'Email'));
$form->addElement(new PasswordInput('password', 'Password'));
$form->addElement(new Button("Submit"))
?>
<?php
$form->render();
?>
