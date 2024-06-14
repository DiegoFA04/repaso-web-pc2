using BasePlatform.API.Insurance.Domain.Services;
using BasePlatform.API.Insurance.Interfaces.REST.Resources;
using BasePlatform.API.Insurance.Interfaces.REST.Transform;
using BasePlatform.API.Properties.Domain.Model.Queries;
using Microsoft.AspNetCore.Mvc;

namespace BasePlatform.API.Insurance.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class PoliciesController(
    IPolicyCommandService policyCommandService,
    IPolicyQueryService policyQueryService
    ): ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> createPolicy([FromBody] CreatePolicyResource createPolicyResource)
    {
        var createPolicyCommand =
            CreatePolicyCommandFromResourceAssembler.ToCommandFromResource(createPolicyResource);
        var policy = await policyCommandService.Handle(createPolicyCommand);
        if (policy is null) return BadRequest();
        var resource = PolicyResourceFromEntityAssembler.ToResourceFromEntity(policy);
        return CreatedAtAction(nameof(GetPolicyById), new { policyId = resource.Id }, resource);
    }

    [HttpGet("{policyId}")]
    public async Task<IActionResult> GetPolicyById([FromRoute] int policyId)
    {
        var policy = await policyQueryService.Handle(new GetPolicyByIdQuery(policyId));
        if (policy == null) return NotFound();
        var resource = PolicyResourceFromEntityAssembler.ToResourceFromEntity(policy);
        return Ok(resource);
    }
}