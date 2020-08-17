package com.ankamagames.dofus.network.messages.game.alliance
{
   import com.ankamagames.dofus.network.types.game.context.roleplay.AllianceInformations;
   import com.ankamagames.dofus.network.types.game.context.roleplay.BasicAllianceInformations;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class KohUpdateMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6439;
       
      
      private var _isInitialized:Boolean = false;
      
      public var alliances:Vector.<AllianceInformations>;
      
      public var allianceNbMembers:Vector.<uint>;
      
      public var allianceRoundWeigth:Vector.<uint>;
      
      public var allianceMatchScore:Vector.<uint>;
      
      public var allianceMapWinner:BasicAllianceInformations;
      
      public var allianceMapWinnerScore:uint = 0;
      
      public var allianceMapMyAllianceScore:uint = 0;
      
      public var nextTickTime:Number = 0;
      
      private var _alliancestree:FuncTree;
      
      private var _allianceNbMemberstree:FuncTree;
      
      private var _allianceRoundWeigthtree:FuncTree;
      
      private var _allianceMatchScoretree:FuncTree;
      
      private var _allianceMapWinnertree:FuncTree;
      
      public function KohUpdateMessage()
      {
         this.alliances = new Vector.<AllianceInformations>();
         this.allianceNbMembers = new Vector.<uint>();
         this.allianceRoundWeigth = new Vector.<uint>();
         this.allianceMatchScore = new Vector.<uint>();
         this.allianceMapWinner = new BasicAllianceInformations();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6439;
      }
      
      public function initKohUpdateMessage(param1:Vector.<AllianceInformations> = null, param2:Vector.<uint> = null, param3:Vector.<uint> = null, param4:Vector.<uint> = null, param5:BasicAllianceInformations = null, param6:uint = 0, param7:uint = 0, param8:Number = 0) : KohUpdateMessage
      {
         this.alliances = param1;
         this.allianceNbMembers = param2;
         this.allianceRoundWeigth = param3;
         this.allianceMatchScore = param4;
         this.allianceMapWinner = param5;
         this.allianceMapWinnerScore = param6;
         this.allianceMapMyAllianceScore = param7;
         this.nextTickTime = param8;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.alliances = new Vector.<AllianceInformations>();
         this.allianceNbMembers = new Vector.<uint>();
         this.allianceRoundWeigth = new Vector.<uint>();
         this.allianceMatchScore = new Vector.<uint>();
         this.allianceMapWinner = new BasicAllianceInformations();
         this.allianceMapMyAllianceScore = 0;
         this.nextTickTime = 0;
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
         this.serializeAs_KohUpdateMessage(param1);
      }
      
      public function serializeAs_KohUpdateMessage(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.alliances.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.alliances.length)
         {
            (this.alliances[_loc2_] as AllianceInformations).serializeAs_AllianceInformations(param1);
            _loc2_++;
         }
         param1.writeShort(this.allianceNbMembers.length);
         var _loc3_:uint = 0;
         while(_loc3_ < this.allianceNbMembers.length)
         {
            if(this.allianceNbMembers[_loc3_] < 0)
            {
               throw new Error("Forbidden value (" + this.allianceNbMembers[_loc3_] + ") on element 2 (starting at 1) of allianceNbMembers.");
            }
            param1.writeVarShort(this.allianceNbMembers[_loc3_]);
            _loc3_++;
         }
         param1.writeShort(this.allianceRoundWeigth.length);
         var _loc4_:uint = 0;
         while(_loc4_ < this.allianceRoundWeigth.length)
         {
            if(this.allianceRoundWeigth[_loc4_] < 0)
            {
               throw new Error("Forbidden value (" + this.allianceRoundWeigth[_loc4_] + ") on element 3 (starting at 1) of allianceRoundWeigth.");
            }
            param1.writeVarInt(this.allianceRoundWeigth[_loc4_]);
            _loc4_++;
         }
         param1.writeShort(this.allianceMatchScore.length);
         var _loc5_:uint = 0;
         while(_loc5_ < this.allianceMatchScore.length)
         {
            if(this.allianceMatchScore[_loc5_] < 0)
            {
               throw new Error("Forbidden value (" + this.allianceMatchScore[_loc5_] + ") on element 4 (starting at 1) of allianceMatchScore.");
            }
            param1.writeByte(this.allianceMatchScore[_loc5_]);
            _loc5_++;
         }
         this.allianceMapWinner.serializeAs_BasicAllianceInformations(param1);
         if(this.allianceMapWinnerScore < 0)
         {
            throw new Error("Forbidden value (" + this.allianceMapWinnerScore + ") on element allianceMapWinnerScore.");
         }
         param1.writeVarInt(this.allianceMapWinnerScore);
         if(this.allianceMapMyAllianceScore < 0)
         {
            throw new Error("Forbidden value (" + this.allianceMapMyAllianceScore + ") on element allianceMapMyAllianceScore.");
         }
         param1.writeVarInt(this.allianceMapMyAllianceScore);
         if(this.nextTickTime < 0 || this.nextTickTime > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.nextTickTime + ") on element nextTickTime.");
         }
         param1.writeDouble(this.nextTickTime);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_KohUpdateMessage(param1);
      }
      
      public function deserializeAs_KohUpdateMessage(param1:ICustomDataInput) : void
      {
         var _loc10_:AllianceInformations = null;
         var _loc11_:uint = 0;
         var _loc12_:uint = 0;
         var _loc13_:uint = 0;
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc10_ = new AllianceInformations();
            _loc10_.deserialize(param1);
            this.alliances.push(_loc10_);
            _loc3_++;
         }
         var _loc4_:uint = param1.readUnsignedShort();
         var _loc5_:uint = 0;
         while(_loc5_ < _loc4_)
         {
            _loc11_ = param1.readVarUhShort();
            if(_loc11_ < 0)
            {
               throw new Error("Forbidden value (" + _loc11_ + ") on elements of allianceNbMembers.");
            }
            this.allianceNbMembers.push(_loc11_);
            _loc5_++;
         }
         var _loc6_:uint = param1.readUnsignedShort();
         var _loc7_:uint = 0;
         while(_loc7_ < _loc6_)
         {
            _loc12_ = param1.readVarUhInt();
            if(_loc12_ < 0)
            {
               throw new Error("Forbidden value (" + _loc12_ + ") on elements of allianceRoundWeigth.");
            }
            this.allianceRoundWeigth.push(_loc12_);
            _loc7_++;
         }
         var _loc8_:uint = param1.readUnsignedShort();
         var _loc9_:uint = 0;
         while(_loc9_ < _loc8_)
         {
            _loc13_ = param1.readByte();
            if(_loc13_ < 0)
            {
               throw new Error("Forbidden value (" + _loc13_ + ") on elements of allianceMatchScore.");
            }
            this.allianceMatchScore.push(_loc13_);
            _loc9_++;
         }
         this.allianceMapWinner = new BasicAllianceInformations();
         this.allianceMapWinner.deserialize(param1);
         this._allianceMapWinnerScoreFunc(param1);
         this._allianceMapMyAllianceScoreFunc(param1);
         this._nextTickTimeFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_KohUpdateMessage(param1);
      }
      
      public function deserializeAsyncAs_KohUpdateMessage(param1:FuncTree) : void
      {
         this._alliancestree = param1.addChild(this._alliancestreeFunc);
         this._allianceNbMemberstree = param1.addChild(this._allianceNbMemberstreeFunc);
         this._allianceRoundWeigthtree = param1.addChild(this._allianceRoundWeigthtreeFunc);
         this._allianceMatchScoretree = param1.addChild(this._allianceMatchScoretreeFunc);
         this._allianceMapWinnertree = param1.addChild(this._allianceMapWinnertreeFunc);
         param1.addChild(this._allianceMapWinnerScoreFunc);
         param1.addChild(this._allianceMapMyAllianceScoreFunc);
         param1.addChild(this._nextTickTimeFunc);
      }
      
      private function _alliancestreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._alliancestree.addChild(this._alliancesFunc);
            _loc3_++;
         }
      }
      
      private function _alliancesFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:AllianceInformations = new AllianceInformations();
         _loc2_.deserialize(param1);
         this.alliances.push(_loc2_);
      }
      
      private function _allianceNbMemberstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._allianceNbMemberstree.addChild(this._allianceNbMembersFunc);
            _loc3_++;
         }
      }
      
      private function _allianceNbMembersFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readVarUhShort();
         if(_loc2_ < 0)
         {
            throw new Error("Forbidden value (" + _loc2_ + ") on elements of allianceNbMembers.");
         }
         this.allianceNbMembers.push(_loc2_);
      }
      
      private function _allianceRoundWeigthtreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._allianceRoundWeigthtree.addChild(this._allianceRoundWeigthFunc);
            _loc3_++;
         }
      }
      
      private function _allianceRoundWeigthFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readVarUhInt();
         if(_loc2_ < 0)
         {
            throw new Error("Forbidden value (" + _loc2_ + ") on elements of allianceRoundWeigth.");
         }
         this.allianceRoundWeigth.push(_loc2_);
      }
      
      private function _allianceMatchScoretreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._allianceMatchScoretree.addChild(this._allianceMatchScoreFunc);
            _loc3_++;
         }
      }
      
      private function _allianceMatchScoreFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readByte();
         if(_loc2_ < 0)
         {
            throw new Error("Forbidden value (" + _loc2_ + ") on elements of allianceMatchScore.");
         }
         this.allianceMatchScore.push(_loc2_);
      }
      
      private function _allianceMapWinnertreeFunc(param1:ICustomDataInput) : void
      {
         this.allianceMapWinner = new BasicAllianceInformations();
         this.allianceMapWinner.deserializeAsync(this._allianceMapWinnertree);
      }
      
      private function _allianceMapWinnerScoreFunc(param1:ICustomDataInput) : void
      {
         this.allianceMapWinnerScore = param1.readVarUhInt();
         if(this.allianceMapWinnerScore < 0)
         {
            throw new Error("Forbidden value (" + this.allianceMapWinnerScore + ") on element of KohUpdateMessage.allianceMapWinnerScore.");
         }
      }
      
      private function _allianceMapMyAllianceScoreFunc(param1:ICustomDataInput) : void
      {
         this.allianceMapMyAllianceScore = param1.readVarUhInt();
         if(this.allianceMapMyAllianceScore < 0)
         {
            throw new Error("Forbidden value (" + this.allianceMapMyAllianceScore + ") on element of KohUpdateMessage.allianceMapMyAllianceScore.");
         }
      }
      
      private function _nextTickTimeFunc(param1:ICustomDataInput) : void
      {
         this.nextTickTime = param1.readDouble();
         if(this.nextTickTime < 0 || this.nextTickTime > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.nextTickTime + ") on element of KohUpdateMessage.nextTickTime.");
         }
      }
   }
}
