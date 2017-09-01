package com.ankamagames.dofus.network.types.game.context.roleplay.job
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class JobCrafterDirectoryListEntry implements INetworkType
   {
      
      public static const protocolId:uint = 196;
       
      
      public var playerInfo:JobCrafterDirectoryEntryPlayerInfo;
      
      public var jobInfo:JobCrafterDirectoryEntryJobInfo;
      
      private var _playerInfotree:FuncTree;
      
      private var _jobInfotree:FuncTree;
      
      public function JobCrafterDirectoryListEntry()
      {
         this.playerInfo = new JobCrafterDirectoryEntryPlayerInfo();
         this.jobInfo = new JobCrafterDirectoryEntryJobInfo();
         super();
      }
      
      public function getTypeId() : uint
      {
         return 196;
      }
      
      public function initJobCrafterDirectoryListEntry(param1:JobCrafterDirectoryEntryPlayerInfo = null, param2:JobCrafterDirectoryEntryJobInfo = null) : JobCrafterDirectoryListEntry
      {
         this.playerInfo = param1;
         this.jobInfo = param2;
         return this;
      }
      
      public function reset() : void
      {
         this.playerInfo = new JobCrafterDirectoryEntryPlayerInfo();
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_JobCrafterDirectoryListEntry(param1);
      }
      
      public function serializeAs_JobCrafterDirectoryListEntry(param1:ICustomDataOutput) : void
      {
         this.playerInfo.serializeAs_JobCrafterDirectoryEntryPlayerInfo(param1);
         this.jobInfo.serializeAs_JobCrafterDirectoryEntryJobInfo(param1);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_JobCrafterDirectoryListEntry(param1);
      }
      
      public function deserializeAs_JobCrafterDirectoryListEntry(param1:ICustomDataInput) : void
      {
         this.playerInfo = new JobCrafterDirectoryEntryPlayerInfo();
         this.playerInfo.deserialize(param1);
         this.jobInfo = new JobCrafterDirectoryEntryJobInfo();
         this.jobInfo.deserialize(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_JobCrafterDirectoryListEntry(param1);
      }
      
      public function deserializeAsyncAs_JobCrafterDirectoryListEntry(param1:FuncTree) : void
      {
         this._playerInfotree = param1.addChild(this._playerInfotreeFunc);
         this._jobInfotree = param1.addChild(this._jobInfotreeFunc);
      }
      
      private function _playerInfotreeFunc(param1:ICustomDataInput) : void
      {
         this.playerInfo = new JobCrafterDirectoryEntryPlayerInfo();
         this.playerInfo.deserializeAsync(this._playerInfotree);
      }
      
      private function _jobInfotreeFunc(param1:ICustomDataInput) : void
      {
         this.jobInfo = new JobCrafterDirectoryEntryJobInfo();
         this.jobInfo.deserializeAsync(this._jobInfotree);
      }
   }
}
