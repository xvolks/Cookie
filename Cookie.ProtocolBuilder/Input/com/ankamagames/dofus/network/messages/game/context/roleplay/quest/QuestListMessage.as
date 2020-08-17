package com.ankamagames.dofus.network.messages.game.context.roleplay.quest
{
   import com.ankamagames.dofus.network.ProtocolTypeManager;
   import com.ankamagames.dofus.network.types.game.context.roleplay.quest.QuestActiveInformations;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class QuestListMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5626;
       
      
      private var _isInitialized:Boolean = false;
      
      public var finishedQuestsIds:Vector.<uint>;
      
      public var finishedQuestsCounts:Vector.<uint>;
      
      public var activeQuests:Vector.<QuestActiveInformations>;
      
      public var reinitDoneQuestsIds:Vector.<uint>;
      
      private var _finishedQuestsIdstree:FuncTree;
      
      private var _finishedQuestsCountstree:FuncTree;
      
      private var _activeQueststree:FuncTree;
      
      private var _reinitDoneQuestsIdstree:FuncTree;
      
      public function QuestListMessage()
      {
         this.finishedQuestsIds = new Vector.<uint>();
         this.finishedQuestsCounts = new Vector.<uint>();
         this.activeQuests = new Vector.<QuestActiveInformations>();
         this.reinitDoneQuestsIds = new Vector.<uint>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5626;
      }
      
      public function initQuestListMessage(param1:Vector.<uint> = null, param2:Vector.<uint> = null, param3:Vector.<QuestActiveInformations> = null, param4:Vector.<uint> = null) : QuestListMessage
      {
         this.finishedQuestsIds = param1;
         this.finishedQuestsCounts = param2;
         this.activeQuests = param3;
         this.reinitDoneQuestsIds = param4;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.finishedQuestsIds = new Vector.<uint>();
         this.finishedQuestsCounts = new Vector.<uint>();
         this.activeQuests = new Vector.<QuestActiveInformations>();
         this.reinitDoneQuestsIds = new Vector.<uint>();
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
         this.serializeAs_QuestListMessage(param1);
      }
      
      public function serializeAs_QuestListMessage(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.finishedQuestsIds.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.finishedQuestsIds.length)
         {
            if(this.finishedQuestsIds[_loc2_] < 0)
            {
               throw new Error("Forbidden value (" + this.finishedQuestsIds[_loc2_] + ") on element 1 (starting at 1) of finishedQuestsIds.");
            }
            param1.writeVarShort(this.finishedQuestsIds[_loc2_]);
            _loc2_++;
         }
         param1.writeShort(this.finishedQuestsCounts.length);
         var _loc3_:uint = 0;
         while(_loc3_ < this.finishedQuestsCounts.length)
         {
            if(this.finishedQuestsCounts[_loc3_] < 0)
            {
               throw new Error("Forbidden value (" + this.finishedQuestsCounts[_loc3_] + ") on element 2 (starting at 1) of finishedQuestsCounts.");
            }
            param1.writeVarShort(this.finishedQuestsCounts[_loc3_]);
            _loc3_++;
         }
         param1.writeShort(this.activeQuests.length);
         var _loc4_:uint = 0;
         while(_loc4_ < this.activeQuests.length)
         {
            param1.writeShort((this.activeQuests[_loc4_] as QuestActiveInformations).getTypeId());
            (this.activeQuests[_loc4_] as QuestActiveInformations).serialize(param1);
            _loc4_++;
         }
         param1.writeShort(this.reinitDoneQuestsIds.length);
         var _loc5_:uint = 0;
         while(_loc5_ < this.reinitDoneQuestsIds.length)
         {
            if(this.reinitDoneQuestsIds[_loc5_] < 0)
            {
               throw new Error("Forbidden value (" + this.reinitDoneQuestsIds[_loc5_] + ") on element 4 (starting at 1) of reinitDoneQuestsIds.");
            }
            param1.writeVarShort(this.reinitDoneQuestsIds[_loc5_]);
            _loc5_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_QuestListMessage(param1);
      }
      
      public function deserializeAs_QuestListMessage(param1:ICustomDataInput) : void
      {
         var _loc10_:uint = 0;
         var _loc11_:uint = 0;
         var _loc12_:uint = 0;
         var _loc13_:QuestActiveInformations = null;
         var _loc14_:uint = 0;
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc10_ = param1.readVarUhShort();
            if(_loc10_ < 0)
            {
               throw new Error("Forbidden value (" + _loc10_ + ") on elements of finishedQuestsIds.");
            }
            this.finishedQuestsIds.push(_loc10_);
            _loc3_++;
         }
         var _loc4_:uint = param1.readUnsignedShort();
         var _loc5_:uint = 0;
         while(_loc5_ < _loc4_)
         {
            _loc11_ = param1.readVarUhShort();
            if(_loc11_ < 0)
            {
               throw new Error("Forbidden value (" + _loc11_ + ") on elements of finishedQuestsCounts.");
            }
            this.finishedQuestsCounts.push(_loc11_);
            _loc5_++;
         }
         var _loc6_:uint = param1.readUnsignedShort();
         var _loc7_:uint = 0;
         while(_loc7_ < _loc6_)
         {
            _loc12_ = param1.readUnsignedShort();
            _loc13_ = ProtocolTypeManager.getInstance(QuestActiveInformations,_loc12_);
            _loc13_.deserialize(param1);
            this.activeQuests.push(_loc13_);
            _loc7_++;
         }
         var _loc8_:uint = param1.readUnsignedShort();
         var _loc9_:uint = 0;
         while(_loc9_ < _loc8_)
         {
            _loc14_ = param1.readVarUhShort();
            if(_loc14_ < 0)
            {
               throw new Error("Forbidden value (" + _loc14_ + ") on elements of reinitDoneQuestsIds.");
            }
            this.reinitDoneQuestsIds.push(_loc14_);
            _loc9_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_QuestListMessage(param1);
      }
      
      public function deserializeAsyncAs_QuestListMessage(param1:FuncTree) : void
      {
         this._finishedQuestsIdstree = param1.addChild(this._finishedQuestsIdstreeFunc);
         this._finishedQuestsCountstree = param1.addChild(this._finishedQuestsCountstreeFunc);
         this._activeQueststree = param1.addChild(this._activeQueststreeFunc);
         this._reinitDoneQuestsIdstree = param1.addChild(this._reinitDoneQuestsIdstreeFunc);
      }
      
      private function _finishedQuestsIdstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._finishedQuestsIdstree.addChild(this._finishedQuestsIdsFunc);
            _loc3_++;
         }
      }
      
      private function _finishedQuestsIdsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readVarUhShort();
         if(_loc2_ < 0)
         {
            throw new Error("Forbidden value (" + _loc2_ + ") on elements of finishedQuestsIds.");
         }
         this.finishedQuestsIds.push(_loc2_);
      }
      
      private function _finishedQuestsCountstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._finishedQuestsCountstree.addChild(this._finishedQuestsCountsFunc);
            _loc3_++;
         }
      }
      
      private function _finishedQuestsCountsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readVarUhShort();
         if(_loc2_ < 0)
         {
            throw new Error("Forbidden value (" + _loc2_ + ") on elements of finishedQuestsCounts.");
         }
         this.finishedQuestsCounts.push(_loc2_);
      }
      
      private function _activeQueststreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._activeQueststree.addChild(this._activeQuestsFunc);
            _loc3_++;
         }
      }
      
      private function _activeQuestsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:QuestActiveInformations = ProtocolTypeManager.getInstance(QuestActiveInformations,_loc2_);
         _loc3_.deserialize(param1);
         this.activeQuests.push(_loc3_);
      }
      
      private function _reinitDoneQuestsIdstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._reinitDoneQuestsIdstree.addChild(this._reinitDoneQuestsIdsFunc);
            _loc3_++;
         }
      }
      
      private function _reinitDoneQuestsIdsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readVarUhShort();
         if(_loc2_ < 0)
         {
            throw new Error("Forbidden value (" + _loc2_ + ") on elements of reinitDoneQuestsIds.");
         }
         this.reinitDoneQuestsIds.push(_loc2_);
      }
   }
}
