package com.ankamagames.dofus.network.messages.game.context.roleplay.job
{
   import com.ankamagames.dofus.network.types.game.context.roleplay.job.JobCrafterDirectorySettings;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class JobCrafterDirectoryDefineSettingsMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5649;
       
      
      private var _isInitialized:Boolean = false;
      
      public var settings:JobCrafterDirectorySettings;
      
      private var _settingstree:FuncTree;
      
      public function JobCrafterDirectoryDefineSettingsMessage()
      {
         this.settings = new JobCrafterDirectorySettings();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5649;
      }
      
      public function initJobCrafterDirectoryDefineSettingsMessage(param1:JobCrafterDirectorySettings = null) : JobCrafterDirectoryDefineSettingsMessage
      {
         this.settings = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.settings = new JobCrafterDirectorySettings();
         this._isInitialized = false;
      }
      
      override public function pack(param1:ICustomDataOutput) : void
      {
         var _loc2_:ByteArray = new ByteArray();
         this.serialize(new CustomDataWrapper(_loc2_));
         writePacket(param1,this.getMessageId(),_loc2_);
      }
      
      override public function unpack(param1:ICustomDataInput, param2:uint) : void
      {
         this.deserialize(param1);
      }
      
      override public function unpackAsync(param1:ICustomDataInput, param2:uint) : FuncTree
      {
         var _loc3_:FuncTree = new FuncTree();
         _loc3_.setRoot(param1);
         this.deserializeAsync(_loc3_);
         return _loc3_;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_JobCrafterDirectoryDefineSettingsMessage(param1);
      }
      
      public function serializeAs_JobCrafterDirectoryDefineSettingsMessage(param1:ICustomDataOutput) : void
      {
         this.settings.serializeAs_JobCrafterDirectorySettings(param1);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_JobCrafterDirectoryDefineSettingsMessage(param1);
      }
      
      public function deserializeAs_JobCrafterDirectoryDefineSettingsMessage(param1:ICustomDataInput) : void
      {
         this.settings = new JobCrafterDirectorySettings();
         this.settings.deserialize(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_JobCrafterDirectoryDefineSettingsMessage(param1);
      }
      
      public function deserializeAsyncAs_JobCrafterDirectoryDefineSettingsMessage(param1:FuncTree) : void
      {
         this._settingstree = param1.addChild(this._settingstreeFunc);
      }
      
      private function _settingstreeFunc(param1:ICustomDataInput) : void
      {
         this.settings = new JobCrafterDirectorySettings();
         this.settings.deserializeAsync(this._settingstree);
      }
   }
}
