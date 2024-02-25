#!/bin/bash

# Read the existing content of config.js
content=$(cat wwwroot/config.js)

# Replace the placeholder with the actual environment variable value
updated_content="${content//<TEST_ENVIRONMENT_VARIABLE>/$TEST_ENVIRONMENT_VARIABLE}"

# Write the updated content back to config.js
echo "$updated_content" > wwwroot/config.js
