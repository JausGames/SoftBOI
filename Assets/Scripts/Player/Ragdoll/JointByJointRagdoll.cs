using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class JointByJointRagdoll : RagdollStatus
{
    [SerializeField] float[] spineAngularDrives;
    [SerializeField] float[] spineMassScales;
    [SerializeField] float[] middleSpineAngularDrives;
    [SerializeField] float[] middleSpineMassScales;
    [SerializeField] float[] neckAngularDrives;
    [SerializeField] float[] neckMassScales;
    [SerializeField] float[] thighsAngularDrives;
    [SerializeField] float[] thighsMassScales;
    [SerializeField] float[] shinsAngularDrives;
    [SerializeField] float[] shinsMassScales;
    [SerializeField] float[] upperarmsAngularDrives;
    [SerializeField] float[] upperarmsMassScales;
    [SerializeField] float[] forearmsAngularDrives;
    [SerializeField] float[] forearmsMassScales;
    [SerializeField] float[] handsAngularDrives;
    [SerializeField] float[] handsMassScales;
    [SerializeField] float[] weaponsAngularDrives;
    [SerializeField] float[] weaponsMassScales;

    public override void ApplyRagdollStatus(JointsManager joints)
    {
        JointDrive jointXDrive = joints.spine.angularXDrive;
        jointXDrive.positionSpring = spineAngularDrives[0];

        JointDrive jointYZDrive = joints.spine.angularYZDrive;
        jointYZDrive.positionSpring = spineAngularDrives[1];

        joints.spine.angularXDrive = jointXDrive;
        joints.spine.angularYZDrive = jointYZDrive;
        joints.spine.massScale = spineMassScales[0];
        joints.spine.connectedMassScale = spineMassScales[1];

        jointXDrive.positionSpring = middleSpineAngularDrives[0];
        jointYZDrive.positionSpring = middleSpineAngularDrives[1];

        joints.middleSpine.angularXDrive = jointXDrive;
        joints.middleSpine.angularYZDrive = jointYZDrive;
        joints.middleSpine.massScale = middleSpineMassScales[0];
        joints.middleSpine.connectedMassScale = middleSpineMassScales[1];

        jointXDrive.positionSpring = neckAngularDrives[0];
        jointYZDrive.positionSpring = neckAngularDrives[1];

        joints.neck.angularXDrive = jointXDrive;
        joints.neck.angularYZDrive = jointYZDrive;
        joints.neck.massScale = neckMassScales[0];
        joints.neck.connectedMassScale = neckMassScales[1];

        jointXDrive.positionSpring = upperarmsAngularDrives[0];
        jointYZDrive.positionSpring = upperarmsAngularDrives[1];

        joints.upperarms[0].angularXDrive = jointXDrive;
        joints.upperarms[0].angularYZDrive = jointYZDrive;
        joints.upperarms[0].massScale = upperarmsMassScales[0];
        joints.upperarms[0].connectedMassScale = upperarmsMassScales[1];

        jointXDrive.positionSpring = upperarmsAngularDrives[2];
        jointYZDrive.positionSpring = upperarmsAngularDrives[3];

        joints.upperarms[1].angularXDrive = jointXDrive;
        joints.upperarms[1].angularYZDrive = jointYZDrive;
        joints.upperarms[1].massScale = upperarmsMassScales[2];
        joints.upperarms[1].connectedMassScale = upperarmsMassScales[3];

        jointXDrive.positionSpring = forearmsAngularDrives[0];
        jointYZDrive.positionSpring = forearmsAngularDrives[1];

        joints.forearms[0].angularXDrive = jointXDrive;
        joints.forearms[0].angularYZDrive = jointYZDrive;
        joints.forearms[0].massScale = forearmsMassScales[0];
        joints.forearms[0].connectedMassScale = forearmsMassScales[1];

        jointXDrive.positionSpring = forearmsAngularDrives[2];
        jointYZDrive.positionSpring = forearmsAngularDrives[3];

        joints.forearms[1].angularXDrive = jointXDrive;
        joints.forearms[1].angularYZDrive = jointYZDrive;
        joints.forearms[1].massScale = forearmsMassScales[2];
        joints.forearms[1].connectedMassScale = forearmsMassScales[3];

        jointXDrive.positionSpring = thighsAngularDrives[0];
        jointYZDrive.positionSpring = thighsAngularDrives[1];

        joints.thighs[0].angularXDrive = jointXDrive;
        joints.thighs[0].angularYZDrive = jointYZDrive;
        joints.thighs[0].massScale = thighsMassScales[0];
        joints.thighs[0].connectedMassScale = thighsMassScales[1];

        jointXDrive.positionSpring = thighsAngularDrives[2];
        jointYZDrive.positionSpring = thighsAngularDrives[3];

        joints.thighs[1].angularXDrive = jointXDrive;
        joints.thighs[1].angularYZDrive = jointYZDrive;
        joints.thighs[1].massScale = thighsMassScales[2];
        joints.thighs[1].connectedMassScale = thighsMassScales[3];

        jointXDrive.positionSpring = shinsAngularDrives[0];
        jointYZDrive.positionSpring = shinsAngularDrives[1];

        joints.shins[0].angularXDrive = jointXDrive;
        joints.shins[0].angularYZDrive = jointYZDrive;
        joints.shins[0].massScale = shinsMassScales[0];
        joints.shins[0].connectedMassScale = shinsMassScales[1];

        jointXDrive.positionSpring = shinsAngularDrives[2];
        jointYZDrive.positionSpring = shinsAngularDrives[3];

        joints.shins[1].angularXDrive = jointXDrive;
        joints.shins[1].angularYZDrive = jointYZDrive;
        joints.shins[1].massScale = shinsMassScales[2];
        joints.shins[1].connectedMassScale = shinsMassScales[3];

        jointXDrive.positionSpring = handsAngularDrives[0];
        jointYZDrive.positionSpring = handsAngularDrives[1];

        joints.hands[0].angularXDrive = jointXDrive;
        joints.hands[0].angularYZDrive = jointYZDrive;
        joints.hands[0].massScale = handsMassScales[0];
        joints.hands[0].connectedMassScale = handsMassScales[1];

        jointXDrive.positionSpring = handsAngularDrives[2];
        jointYZDrive.positionSpring = handsAngularDrives[3];

        joints.hands[1].angularXDrive = jointXDrive;
        joints.hands[1].angularYZDrive = jointYZDrive;
        joints.hands[1].massScale = handsMassScales[2];
        joints.hands[1].connectedMassScale = handsMassScales[3];

        jointXDrive.positionSpring = weaponsAngularDrives[0];
        jointYZDrive.positionSpring = weaponsAngularDrives[1];

        joints.weapons[0].angularXDrive = jointXDrive;
        joints.weapons[0].angularYZDrive = jointYZDrive;
        joints.weapons[0].massScale = weaponsMassScales[0];
        joints.weapons[0].connectedMassScale = weaponsMassScales[1];

        jointXDrive.positionSpring = weaponsAngularDrives[2];
        jointYZDrive.positionSpring = weaponsAngularDrives[3];

        joints.weapons[1].angularXDrive = jointXDrive;
        joints.weapons[1].angularYZDrive = jointYZDrive;
        joints.weapons[1].massScale = weaponsMassScales[2];
        joints.weapons[1].connectedMassScale = weaponsMassScales[3];

    }
}
