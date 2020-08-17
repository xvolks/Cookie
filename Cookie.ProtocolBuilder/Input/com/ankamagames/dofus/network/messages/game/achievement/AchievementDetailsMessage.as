package com.ankamagames.dofus.network.messages.game.achievement
{
   import com.ankamagames.dofus.network.types.game.achievement.Achievement;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class AchievementDetailsMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6378;
       
      
      private var _isInitialized:Boolean = false;
      
      public var achievement:Achievement;
      
      private var _achievementtree:FuncTree;
      
      public function AchievementDetailsMessage()
      {
         this.achievement = new Achievement();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6378;
      }
      
      public function initAchievementDetailsMessage(param1:Achievement = null) : AchievementDetailsMessage
      {
         this.achievement = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.achievement = new Achievement();
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
         this.serializeAs_AchievementDetailsMessage(param1);
      }
      
      public function serializeAs_AchievementDetailsMessage(param1:ICustomDataOutput) : void
      {
         this.achievement.serializeAs_Achievement(param1);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_AchievementDetailsMessage(param1);
      }
      
      public function deserializeAs_AchievementDetailsMessage(param1:ICustomDataInput) : void
      {
         this.achievement = new Achievement();
         this.achievement.deserialize(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_AchievementDetailsMessage(param1);
      }
      
      public function deserializeAsyncAs_AchievementDetailsMessage(param1:FuncTree) : void
      {
         this._achievementtree = param1.addChild(this._achievementtreeFunc);
      }
      
      private function _achievementtreeFunc(param1:ICustomDataInput) : void
      {
         this.achievement = new Achievement();
         this.achievement.deserializeAsync(this._achievementtree);
      }
   }
}
