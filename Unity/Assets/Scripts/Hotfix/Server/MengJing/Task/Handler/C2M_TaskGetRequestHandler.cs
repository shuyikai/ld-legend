namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    [FriendOf(typeof(TaskComponentS))]
    public class C2M_TaskGetRequestHandler : MessageLocationHandler<Unit, C2M_TaskGetRequest, M2C_TaskGetResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_TaskGetRequest request, M2C_TaskGetResponse response)
        {
            if (!TaskConfigCategory.Instance.Contain(request.TaskId))
            {
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            TaskConfig taskConfig = TaskConfigCategory.Instance.Get(request.TaskId);
            if (taskConfig.TaskType == TaskTypeEnum.Daily)
            {
                TaskComponentS taskComponent = unit.GetComponent<TaskComponentS>();
                if (taskComponent.GetTaskList(TaskTypeEnum.Daily).Count > 0)
                {
                    response.Error = ErrorCode.ERR_TaskCanNotGet;
                    return;
                }
                
            }
            else if (taskConfig.TaskType == TaskTypeEnum.Union)
            {
                TaskComponentS taskComponent = unit.GetComponent<TaskComponentS>();
                if (taskComponent.GetTaskList(TaskTypeEnum.Union).Count > 0)
                {
                    response.Error = ErrorCode.ERR_TaskNoComplete;
                    return;
                }

            }
            else if (taskConfig.TaskType == TaskTypeEnum.Treasure)
            {
                
                if (unit.GetComponent<TaskComponentS>().GetTaskList(taskConfig.TaskType).Count > 1)
                {
                    response.Error = ErrorCode.ERR_TaskNoComplete;
                    return;
                }
                (TaskPro taskPro, int error) = unit.GetComponent<TaskComponentS>().OnAcceptedTask(request.TaskId);
                response.Error = error;
                response.TaskPro = taskPro;
            }
            else if (taskConfig.TaskType == TaskTypeEnum.Ring)
            {
                if (unit.GetComponent<TaskComponentS>().GetTaskList(taskConfig.TaskType).Count > 1)
                {
                    response.Error = ErrorCode.ERR_TaskNoComplete;
                    return;
                }
                (TaskPro taskPro, int error) = unit.GetComponent<TaskComponentS>().OnAcceptedTask(request.TaskId);
                response.Error = error;
                response.TaskPro = taskPro;
            }
            else
            {
                (TaskPro taskPro, int error) = unit.GetComponent<TaskComponentS>().OnAcceptedTask(request.TaskId);
                response.Error = error;
                response.TaskPro = taskPro;
            }
            await ETTask.CompletedTask;
        }
    }
}
