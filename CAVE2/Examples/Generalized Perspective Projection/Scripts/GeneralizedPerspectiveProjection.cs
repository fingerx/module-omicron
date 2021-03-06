﻿/**************************************************************************************************
 * 
 *-------------------------------------------------------------------------------------------------
 * Copyright 2018   		Electronic Visualization Laboratory, University of Illinois at Chicago
 * Authors:										
 *  Arthur Nishimoto		anishimoto42@gmail.com
 *-------------------------------------------------------------------------------------------------
 * Copyright (c) 2018, Electronic Visualization Laboratory, University of Illinois at Chicago
 * All rights reserved.
 * Redistribution and use in source and binary forms, with or without modification, are permitted 
 * provided that the following conditions are met:
 * 
 * Redistributions of source code must retain the above copyright notice, this list of conditions 
 * and the following disclaimer. Redistributions in binary form must reproduce the above copyright 
 * notice, this list of conditions and the following disclaimer in the documentation and/or other 
 * materials provided with the distribution. 
 * 
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR 
 * IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND 
 * FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR 
 * CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL 
 * DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE  GOODS OR SERVICES; LOSS OF 
 * USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, 
 * WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN 
 * ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 *************************************************************************************************/
using UnityEngine;

// This is an implementation of Generalized Perspective Projection based on a paper of the same name
// by Robert Kooima, August 2008 / revised June 2009
// http://csc.lsu.edu/~kooima/pdfs/gen-perspective.pdf
// Additional references on Unity-specific implementation
// https://forum.unity.com/threads/off-axis-projection-with-unity.192409/
public class GeneralizedPerspectiveProjection : MonoBehaviour {

    [SerializeField]
    Vector3 screenUL = new Vector3(-1.0215f, 2.476f, -0.085972f);

    [SerializeField]
    Vector3 screenLL = new Vector3(-1.0215f, 1.324f, -0.085972f);

    [SerializeField]
    Vector3 screenLR = new Vector3(1.0215f, 1.324f, -0.085972f);

    [SerializeField]
    Transform head;

    [SerializeField]
    bool debug = false;

    bool useProjection = true;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if (useProjection)
        {
            Vector3 trackingOffset = transform.root.position;
            Projection(screenLL, screenLR, screenUL, head.position - trackingOffset, Camera.main.nearClipPlane, Camera.main.farClipPlane);
        }
    }

    // pa = Screen position - Lower left corner
    // pb = Screen position - Lower right corner
    // pc = Screen position - Upper left corner
    // pe = Viewer/camera position
    // n = Near clipping plane
    // f = Far clipping plane
    void Projection( Vector3 pa, Vector3 pb, Vector3 pc, Vector3 pe, float n, float f)
    {
        // Non-unit vectors of screen corners
        Vector3 va, vb, vc;

        // Perpendicular unit vectors of orthonormal screen space
        // Right, Up, Normal
        Vector3 vr, vu, vn;

        float l, r, b, t;
        Matrix4x4 M = new Matrix4x4();

        // Compute an orthonormal basis for screen
        vr = pb - pa;
        vu = pc - pa;

        vr = Vector3.Normalize(vr);
        vu = Vector3.Normalize(vu);
        vn = Vector3.Cross(vr, vu).normalized;

        // Compute the screen corner vectors
        va = pa - pe;
        vb = pb - pe;
        vc = pc - pe;

        if (debug)
        {
            Debug.DrawRay(Camera.main.transform.position, va, Color.green);
            Debug.DrawRay(Camera.main.transform.position, vb, Color.green);
            Debug.DrawRay(Camera.main.transform.position, vc, Color.green);
        }

        // Find the distance between the eye to screen plane
        float d = Vector3.Dot(va, vn);

        // Find the extent of the perpendicular projection
        l = Vector3.Dot(vr, va) * n / d;
        r = Vector3.Dot(vr, vb) * n / d;
        b = Vector3.Dot(vu, va) * n / d;
        t = Vector3.Dot(vu, vc) * n / d;

        //M[0] = vr[0]; M[4] = vr[1]; M[8] = vr[2];
        //M[1] = vu[0]; M[5] = vu[1]; M[9] = vu[2];
        //M[2] = vn[0]; M[6] = vn[1]; M[10] = vn[2];
        //M[15] = 1.0f;

        M[0, 0] = 2.0f * n / (r - l);
        M[0, 2] = (r + l) / (r - l);
        M[1, 1] = 2.0f * n / (t - b);
        M[1, 2] = (t + b) / (t - b);
        M[2, 2] = (f + n) / (n - f);
        M[2, 3] = 2.0f * f * n / (n - f);
        M[3, 2] = -1.0f;

        GetComponent<Camera>().projectionMatrix = M;
        GetComponent<Camera>().transform.localPosition = pe;
    }

    public void UseProjection(bool value)
    {
        useProjection = value;
    }
}
