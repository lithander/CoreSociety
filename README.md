CoreSociety
===========

Core Society is a digital organism simulator based on a grid of programmable Cores.
Not unlike a cellular automata a core can affect the state of its 4 direct neighbours. 

Each core has 256 words of memory and an intruction pointer pointing at a specific memory adress. When the core gains execution focus that word is interpreted as an instruction. The instruction set is similar to that of ordinary CPUs and allows the core to act like a tiny computer. It includes the ability to reserve and release energy which is used up by executing instructions and also determines which core is the next in line to execute: the core with the currently highest unbound energy!

There are no free instructions and one core will always have execution focus. So even a grid only consisting of uninitialized cores will leak energy.

The simulator ships with a handful of missions. The task is usually to beat a certain score threshold by defining the initial memory layout of a subset of the grid's cores. As soon as the simulation start's there's no way to interact with the outcome so you have to come up with a smart strategy, an efficient implementation and that usually means doing lot's of iterations.

All but the most basic missions will require your program to write to the memory of adjacent cores to change their program and thus make them work towards your goal. Usually the grid is initialized with "enemy" cores who will try to prevent you from achieving a high score by spending all their energy to decrease the score. So the first part of the sim is usually spend on getting board control, then you can spend the remaining total energy budget on getting the score up.

