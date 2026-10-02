# VR-Injection-Training

## Submission Notes

### Target Device

OpenXR-compatible VR headset with two motion controllers. The project was developed and tested using the XR Interaction Simulator, allowing the core interactions to be tested without a physical headset.

### Unity Version

* Unity 6
* Unity 6000.3.2f1
* XR Interaction Toolkit 3.4.1
* OpenXR Plugin

### Controls

**Editor / Simulator**

* **Mouse** — Look / interact with the simulated XR environment
* **E** — Pull medication from the ampoule
* **I** — Inject medication
* **R** — Restart the training session
* **Grip / configured interaction key** — Grab and release objects

**VR**

* Grab the syringe with one controller and the ampoule with the other.
* Use the configured controller input to draw medication and perform the injection.
* The interaction logic is implemented through Unity's Input System so the same actions can be mapped to VR controller inputs.

### Assets & Packages

The project uses Unity's XR ecosystem, primarily:

* XR Interaction Toolkit 3.4.1
* OpenXR Plugin
* Unity Input System
* TextMeshPro
* Unity's built-in rendering and UI systems

Additional environment and visual assets are included in the project where applicable. Custom scripts were written for the syringe, ampoule, medication, injection target, training progression, and reset functionality.

### What I Would Improve With More Time

With additional development time, I would focus on:

* More polished visual and audio feedback for each training step.
* More robust error handling and guidance for incorrect actions.
* Improved object placement and grab ergonomics.
* More detailed hand/controller visualization and VR-specific interaction polish.
* Additional training steps and scenarios.
* More extensive testing on physical OpenXR hardware.
* Improved visual fidelity of the hospital environment and medical equipment.


## How To Play

1. Go next to the tray and grab the syringe with one hand and ampoule with another such that they're aligned
<img width="800" height="450" alt="1st" src="https://github.com/user-attachments/assets/f1be3c29-8a2f-43cc-8754-fc3fb3c45696" />


2. Press V (Keyboard)/ Move Primary2DAxis along Y direction (LeftorRight XR Simulated Controller) to draw medication
<img width="800" height="450" alt="2nd" src="https://github.com/user-attachments/assets/304d2611-f129-4db9-bab8-d41e2f20c83b" />


3. Press C (Keyboard)/ PrimaryButton(Left or Right XR Controller) to inject patient
<img width="800" height="450" alt="3rd" src="https://github.com/user-attachments/assets/e41d4bb3-3b9d-45ca-91ed-ba621a5168af" />
