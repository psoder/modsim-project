# Project Specification

2022-02-23
| Name | KTH mail |
| ------------------------- | ------------- |
| Pontus Söderlund | psoder@kth.se |
| Michael Morales Sundstedt | micms@kth.se |

## Grade
We're aiming for a pass, but we both believe that this question is pretty stupid
since the grade should be based on what we've done and not what grade we're 
aiming for.

## Simulating Orbital Mechanics

Not a Master Thesis Proposal

## Background / Problem

In order to make a well functioning Solar System simulation, one has to take into
consideration the physical phenomenons that is in play. These are the all
gravitational forces from the planets, which keeps the planets in orbit. The
gravitational force will be calculated with the help of Newton's law of universal
gravity, $F=G \frac{m_1 \cdot m_2}{r^2}$<sup>[1](#References)</sup>. Furthermore,
a aproximation method is needed to evaluate velocity, direction and acceleration.
This can be done with whichever approximation method, such as the Euler
Method<sup>[2](#References)</sup> or Runge Kutta 4<sup>[3](#References)</sup>.

## Implementation

This project will be a 3D implementation of the solar system complete with all
the major celestial bodies, i.e. one star, eight planets and maybe a moon or two.
See Figure 1.

![image](https://user-images.githubusercontent.com/52171526/159247128-05a51689-1d46-474a-9245-4c2b32992a23.png)
Figure 1: The Solar System

The celestial objects will be implemented as spheres of different sizes with
different masses and different positions. Newton's law of universal gravity will
then be used to calculate the force acting upon the different bodies.

Unity will be used to display and run the simulation aswell as making it look
pretty. The code will consist of C# files that act as scripts in Unity. The
scripts will handle all the physics.

## References

Links to refrences used above.

1: [Newton's law of universal gravity](https://en.wikipedia.org/wiki/Gravity)

2: [Euler_method](https://en.wikipedia.org/wiki/Euler_method)

3: [Runge Kutta 4](https://en.wikipedia.org/wiki/Runge%E2%80%93Kutta_methods)

## Potential risks/challenges

- Unity may not be sutitable for astronomical scales.
- As with all simulations accuracy is something that needs to be taken into consideration.
- None of us have used a lot of Unity.
- We're not phycisists and haven't touched physics sinec upper secondary school.

## Degree of simulation

Since the participants of the project is of novice level regarding usage of
Unity, most implementations will be built from scrath. Though if suituble and
relevent features/libraries get's discovered one can expect them to be used. The
physical calculations will be implemented by us.

## Link to blog containing first entry

Link to the blog can be found [here](https://github.com/psoder/modsim-project/wiki).
