# Main PSS Program

Welcome to the main program!

Here you'll find all the main interfaces for the PSS call center agents to capture and manage PSS clients data.

The only part not included in this section is the Client Satisfaction interface.
>That, is in the PSS-ClientSatisfaction directory.

# Troubleshooting

Some problems we came accross and had to fix are documented here.

## Program Throws An SQL Network error on startup
The program cannot connect to the SQL server. Did you start the SQL container?

## User Controls Preventing Solution Building
One of the problems you might experiance is when the user controls don't load correctly.
This causes the build to fail. this happens becuase the user controls aren't in development assembly.

The Way to fix it is to rebuild the solution by Clicking on `Build -> Rebuild Solution`

The problem is becuase the references to user controls that are not in the assembly, they cause build errors!
The only way we found to fix this is to comment out everywhere there is a reference to a user control, then clicking Clicking on `Build -> Rebuild Solution`.
