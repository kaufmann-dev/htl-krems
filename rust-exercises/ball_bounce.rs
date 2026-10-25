// Bouncing ball animation in Rust

use std::time::Duration;
use std::thread;

const SPIN_SPEED: u64 = 50; // Adjust spin speed as desired

fn main() {
    let mut ball_position = 0;
    let mut ball_velocity = 1;

    loop {
        // Clear the screen
        print!("\x1B[2J");

        // Move the cursor to the top-left corner
        print!("\x1B[1;1H");

        // Print the ball at its current position
        for i in 0..5 {
            if i == ball_position {
                println!("o");
            } else {
                println!(" ");
            }
        }

        // Update the ball's position and velocity
        ball_position += ball_velocity;
        if ball_position == 0 || ball_position == 4 {
            ball_velocity = -ball_velocity;
        }

        // Sleep for a short time to create the animation effect
        thread::sleep(Duration::from_millis(SPIN_SPEED));
    }
}
