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
   public class JobCrafterDirectorySettingsMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5652;
       
      
      private var _isInitialized:Boolean = false;
      
      public var craftersSettings:Vector.<JobCrafterDirectorySettings>;
      
      private var _craftersSettingstree:FuncTree;
      
      public function JobCrafterDirectorySettingsMessage()
      {
         this.craftersSettings = new Vector.<JobCrafterDirectorySettings>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5652;
      }
      
      public function initJobCrafterDirectorySettingsMessage(param1:Vector.<JobCrafterDirectorySettings> = null) : JobCrafterDirectorySettingsMessage
      {
         this.craftersSettings = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.craftersSettings = new Vector.<JobCrafterDirectorySettings>();
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
         this.serializeAs_JobCrafterDirectorySettingsMessage(param1);
      }
      
      public function serializeAs_JobCrafterDirectorySettingsMessage(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.craftersSettings.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.craftersSettings.length)
         {
            (this.craftersSettings[_loc2_] as JobCrafterDirectorySettings).serializeAs_JobCrafterDirectorySettings(param1);
            _loc2_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_JobCrafterDirectorySettingsMessage(param1);
      }
      
      public function deserializeAs_JobCrafterDirectorySettingsMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:JobCrafterDirectorySettings = null;
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = new JobCrafterDirectorySettings();
            _loc4_.deserialize(param1);
            this.craftersSettings.push(_loc4_);
            _loc3_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_JobCrafterDirectorySettingsMessage(param1);
      }
      
      public function deserializeAsyncAs_JobCrafterDirectorySettingsMessage(param1:FuncTree) : void
      {
         this._craftersSettingstree = param1.addChild(this._craftersSettingstreeFunc);
      }
      
      private function _craftersSettingstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._craftersSettingstree.addChild(this._craftersSettingsFunc);
            _loc3_++;
         }
      }
      
      private function _craftersSettingsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:JobCrafterDirectorySettings = new JobCrafterDirectorySettings();
         _loc2_.deserialize(param1);
         this.craftersSettings.push(_loc2_);
      }
   }
}
