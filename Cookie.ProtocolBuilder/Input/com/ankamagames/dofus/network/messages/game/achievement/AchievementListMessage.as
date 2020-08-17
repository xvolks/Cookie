package com.ankamagames.dofus.network.messages.game.achievement
{
   import com.ankamagames.dofus.network.types.game.achievement.AchievementRewardable;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class AchievementListMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6205;
       
      
      private var _isInitialized:Boolean = false;
      
      public var finishedAchievementsIds:Vector.<uint>;
      
      public var rewardableAchievements:Vector.<AchievementRewardable>;
      
      private var _finishedAchievementsIdstree:FuncTree;
      
      private var _rewardableAchievementstree:FuncTree;
      
      public function AchievementListMessage()
      {
         this.finishedAchievementsIds = new Vector.<uint>();
         this.rewardableAchievements = new Vector.<AchievementRewardable>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6205;
      }
      
      public function initAchievementListMessage(param1:Vector.<uint> = null, param2:Vector.<AchievementRewardable> = null) : AchievementListMessage
      {
         this.finishedAchievementsIds = param1;
         this.rewardableAchievements = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.finishedAchievementsIds = new Vector.<uint>();
         this.rewardableAchievements = new Vector.<AchievementRewardable>();
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
         this.serializeAs_AchievementListMessage(param1);
      }
      
      public function serializeAs_AchievementListMessage(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.finishedAchievementsIds.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.finishedAchievementsIds.length)
         {
            if(this.finishedAchievementsIds[_loc2_] < 0)
            {
               throw new Error("Forbidden value (" + this.finishedAchievementsIds[_loc2_] + ") on element 1 (starting at 1) of finishedAchievementsIds.");
            }
            param1.writeVarShort(this.finishedAchievementsIds[_loc2_]);
            _loc2_++;
         }
         param1.writeShort(this.rewardableAchievements.length);
         var _loc3_:uint = 0;
         while(_loc3_ < this.rewardableAchievements.length)
         {
            (this.rewardableAchievements[_loc3_] as AchievementRewardable).serializeAs_AchievementRewardable(param1);
            _loc3_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_AchievementListMessage(param1);
      }
      
      public function deserializeAs_AchievementListMessage(param1:ICustomDataInput) : void
      {
         var _loc6_:uint = 0;
         var _loc7_:AchievementRewardable = null;
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc6_ = param1.readVarUhShort();
            if(_loc6_ < 0)
            {
               throw new Error("Forbidden value (" + _loc6_ + ") on elements of finishedAchievementsIds.");
            }
            this.finishedAchievementsIds.push(_loc6_);
            _loc3_++;
         }
         var _loc4_:uint = param1.readUnsignedShort();
         var _loc5_:uint = 0;
         while(_loc5_ < _loc4_)
         {
            _loc7_ = new AchievementRewardable();
            _loc7_.deserialize(param1);
            this.rewardableAchievements.push(_loc7_);
            _loc5_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_AchievementListMessage(param1);
      }
      
      public function deserializeAsyncAs_AchievementListMessage(param1:FuncTree) : void
      {
         this._finishedAchievementsIdstree = param1.addChild(this._finishedAchievementsIdstreeFunc);
         this._rewardableAchievementstree = param1.addChild(this._rewardableAchievementstreeFunc);
      }
      
      private function _finishedAchievementsIdstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._finishedAchievementsIdstree.addChild(this._finishedAchievementsIdsFunc);
            _loc3_++;
         }
      }
      
      private function _finishedAchievementsIdsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readVarUhShort();
         if(_loc2_ < 0)
         {
            throw new Error("Forbidden value (" + _loc2_ + ") on elements of finishedAchievementsIds.");
         }
         this.finishedAchievementsIds.push(_loc2_);
      }
      
      private function _rewardableAchievementstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._rewardableAchievementstree.addChild(this._rewardableAchievementsFunc);
            _loc3_++;
         }
      }
      
      private function _rewardableAchievementsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:AchievementRewardable = new AchievementRewardable();
         _loc2_.deserialize(param1);
         this.rewardableAchievements.push(_loc2_);
      }
   }
}
